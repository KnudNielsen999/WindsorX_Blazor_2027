namespace WindsorX_2027.IndkoebsRepositoryMappe
{
    using Microsoft.EntityFrameworkCore;
    using WindsorX_2027.DB_Entity;
    using WindsorX_2027.IndkoebsModel;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using WindsorX_2027.LagerRepositoryMappe;
    using BaggrundsDataLibrary.LagerTransAktioner;

    public class IndkobRepository : IIndkobRepository
    {
        private readonly Entity_Database _context;
        private readonly ILagerRepository _lagerRepository;

        public IndkobRepository(Entity_Database context, ILagerRepository lagerRepository)
        {
            _context = context;
            _lagerRepository = lagerRepository;
        }

        public async Task CreateIndkobAsync(IndkobModel indkob)
        {
            _context.Add(indkob);
            await _context.SaveChangesAsync();

            indkob.ordreNummer = $"Ind_{indkob.Id}";
            _context.Update(indkob);
            await _context.SaveChangesAsync();
        }

        public async Task<List<IndkobModel>> GetAllIndkobAsync()
        {
            return await _context.IndkobsOrdre.AsNoTracking().ToListAsync();
        }

        public async Task<IndkobModel> GetIndkobByIdAsync(int id)
        {
            var indkob = await _context.IndkobsOrdre
                .Include(i => i.ordreLinjer)
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.Id == id);

            return indkob ?? throw new KeyNotFoundException($"Ingen indkøbsordre fundet med ID: {id}");
        }

        public async Task UpdateIndkobAsync(IndkobModel indkob)
        {
            var existingIndkob = await _context.IndkobsOrdre
                .Include(i => i.ordreLinjer)
                .FirstOrDefaultAsync(i => i.Id == indkob.Id);

            if (existingIndkob == null)
                throw new KeyNotFoundException($"Indkøbsordre med ID {indkob.Id} blev ikke fundet.");

            _context.Entry(existingIndkob).CurrentValues.SetValues(indkob);

            existingIndkob.ordreLinjer.RemoveAll(ordreLinje =>
                !indkob.ordreLinjer.Any(o => o.Id == ordreLinje.Id));

            foreach (var ordreLinje in indkob.ordreLinjer)
            {
                var existingLinje = existingIndkob.ordreLinjer
                    .FirstOrDefault(o => o.Id == ordreLinje.Id);

                if (existingLinje != null)
                {
                    _context.Entry(existingLinje).CurrentValues.SetValues(ordreLinje);
                }
                else
                {
                    existingIndkob.ordreLinjer.Add(ordreLinje);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteIndkobAsync(int id)
        {
            var indkob = await _context.IndkobsOrdre
                .Include(i => i.ordreLinjer)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (indkob != null)
            {
                _context.IndkobsOrdre.Remove(indkob);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Kunne ikke finde indkøbsordren med ID: " + id);
            }
        }

        public async Task<IndkobModel?> GetIndkobByOrdreNummerAsync(string ordreNummer)
        {
            return await _context.IndkobsOrdre
                .Include(i => i.ordreLinjer)
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.ordreNummer == ordreNummer);
        }

        public async Task<bool> DoesOrdreNummerExistAsync(string ordreNummer)
        {
            return await _context.IndkobsOrdre.AnyAsync(i => i.ordreNummer == ordreNummer);
        }

        public async Task<List<IndkobModel>> SearchByOrdreNummerAsync(string ordreNummer)
        {
            return await _context.IndkobsOrdre
                .Where(i => i.ordreNummer == ordreNummer)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<IndkobModel>> GetOpenIndkobsAsync()
        {
            return await _context.IndkobsOrdre
                .Where(o => o.open)
                .OrderBy(o => o.ordreDato)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task CloseOrderAsync(string ordreNummer)
        {
            var ordre = await _context.IndkobsOrdre.FirstOrDefaultAsync(o => o.ordreNummer == ordreNummer);
            if (ordre != null)
            {
                ordre.open = false;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteOrderAsync(string ordreNummer)
        {
            var ordre = await _context.IndkobsOrdre
                .Include(o => o.ordreLinjer)
                .FirstOrDefaultAsync(o => o.ordreNummer == ordreNummer);

            if (ordre != null)
            {
                foreach (var ordreLinje in ordre.ordreLinjer)
                {
                    var vare = await _lagerRepository.GetVareByVarenummerAsync(ordreLinje.vareNummer);
                    if (vare != null)
                    {
                        vare.bestiltAntal = Math.Max((vare.bestiltAntal ?? 0) - (ordreLinje.ordreAntal ?? 0), 0);
                        await _lagerRepository.UpdateItemAsync(vare);
                    }
                }

                _context.IndkobsOrdre.Remove(ordre);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Ordren med ordreNummer {ordreNummer} blev ikke fundet.");
            }
        }

        public async Task OpdaterBestiltAntalForVarenummerAsync(string varenummer)
        {
            var ordrerMedVarenummer = await _context.IndkobsOrdre
                .Include(i => i.ordreLinjer)
                .Where(i => i.open && i.ordreLinjer.Any(l => l.vareNummer == varenummer))
                .AsNoTracking()
                .ToListAsync();

            var samletAntal = ordrerMedVarenummer
                .SelectMany(o => o.ordreLinjer)
                .Where(l => l.vareNummer == varenummer)
                .Sum(l => l.ordreAntal ?? 0);

            var lagerPost = await _lagerRepository.GetVareByVarenummerAsync(varenummer);
            if (lagerPost != null)
            {
                lagerPost.bestiltAntal = samletAntal;
                lagerPost.sidsteBestillingsDato = DateTime.Now;
                await _lagerRepository.UpdateItemAsync(lagerPost);
            }
            else
            {
                throw new KeyNotFoundException($"Lagerpost for varenummer {varenummer} blev ikke fundet.");
            }
        }
    }
}
