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

        // Opret en ny indkøbsordre
        public async Task CreateIndkobAsync(IndkobModel indkob)
        {
            // Tilføj den nye indkøbsordre til konteksten
            _context.Attach(indkob);
            _context.Add(indkob);

            // Gem for at få tildelt ID'et fra databasen
            await _context.SaveChangesAsync();

            // Generér ordrenummer baseret på det tildelte ID
            indkob.ordreNummer = $"Ind_{indkob.Id}";

            // Opdater ordren med det nye ordrenummer
            _context.Update(indkob); // Marker entiteten som ændret
            await _context.SaveChangesAsync(); // Gem ændringen
        }


        // Hent alle indkøbsordrer
        public async Task<List<IndkobModel>> GetAllIndkobAsync()
        {
            return await _context.IndkobsOrdre.ToListAsync();
        }

        // Hent en indkøbsordre efter ID
        public async Task<IndkobModel> GetIndkobByIdAsync(int id)
        {
            var indkob = await _context.IndkobsOrdre
                .Include(i => i.ordreLinjer)
                .FirstOrDefaultAsync(i => i.Id == id);

            return indkob ?? throw new KeyNotFoundException($"Ingen indkøbsordre fundet med ID: {id}");
        }


        // Opdater en indkøbsordre
        public async Task UpdateIndkobAsync(IndkobModel indkob)
        {
            // Hent eksisterende IndkobModel fra databasen, inklusive ordreLinjer
            var existingIndkob = await _context.IndkobsOrdre
                .Include(i => i.ordreLinjer) // Inkluder ordrelinjer for korrekt opdatering
                .FirstOrDefaultAsync(i => i.Id == indkob.Id);

            if (existingIndkob == null)
                throw new KeyNotFoundException($"Indkøbsordre med ID {indkob.Id} blev ikke fundet.");

            // Opdater hovedmodellen
            _context.Entry(existingIndkob).CurrentValues.SetValues(indkob);

            // Håndter ordrelinjer
            // 1. Fjern ordrelinjer, som ikke længere findes i den nye model
            existingIndkob.ordreLinjer.RemoveAll(ordreLinje =>
                !indkob.ordreLinjer.Any(o => o.Id == ordreLinje.Id));

            // 2. Tilføj eller opdater eksisterende ordrelinjer
            foreach (var ordreLinje in indkob.ordreLinjer)
            {
                var existingLinje = existingIndkob.ordreLinjer
                    .FirstOrDefault(o => o.Id == ordreLinje.Id);

                if (existingLinje != null)
                {
                    // Opdater eksisterende ordrelinje
                    _context.Entry(existingLinje).CurrentValues.SetValues(ordreLinje);
                }
                else
                {
                    // Tilføj ny ordrelinje
                    existingIndkob.ordreLinjer.Add(ordreLinje);
                }
            }

            // Gem ændringer
            await _context.SaveChangesAsync();
        }




        // Slet en indkøbsordre
        public async Task DeleteIndkobAsync(int id)
        {
            var indkob = await _context.IndkobsOrdre
                .Include(i => i.ordreLinjer) // Inkluderer ordrelinjer for at slette relaterede data
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


        // Hent en indkøbsordre baseret på ordreNummer
        public async Task<IndkobModel?> GetIndkobByOrdreNummerAsync(string ordreNummer)
        {
            return await _context.IndkobsOrdre
                .Include(i => i.ordreLinjer) // Inkluder relaterede ordrelinjer
                .FirstOrDefaultAsync(i => i.ordreNummer == ordreNummer);
        }



        // Tjekker om en ordreNummerId allerede eksisterer
        public async Task<bool> DoesOrdreNummerExistAsync(string ordreNummer)
        {
            return await _context.IndkobsOrdre.AnyAsync(i => i.ordreNummer == ordreNummer);
        }

        // Søg efter indkøbsordrer baseret på ordreNummer
        public async Task<List<IndkobModel>> SearchByOrdreNummerAsync(string ordreNummer)
        {
            return await _context.IndkobsOrdre
                .Where(i => i.ordreNummer == ordreNummer)
                .ToListAsync();
        }

        public async Task<List<IndkobModel>> GetOpenIndkobsAsync()
        {
            return await _context.IndkobsOrdre
                .Where(o => o.open == true) // Eller en tilsvarende logik for at markere åbne ordrer
                .OrderBy(o => o.ordreDato) // Sortér efter dato, hvis det er relevant
                .ToListAsync();
        }

        public async Task CloseOrderAsync(string ordreNummer)
        {
            var ordre = await _context.IndkobsOrdre.FirstOrDefaultAsync(o => o.ordreNummer == ordreNummer);
            if (ordre != null)
            {
                ordre.open = false; // Eller en tilsvarende logik
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteOrderAsync(string ordreNummer)
        {
            // Find ordren inklusiv ordrelinjer
            var ordre = await _context.IndkobsOrdre
                .Include(o => o.ordreLinjer)
                .FirstOrDefaultAsync(o => o.ordreNummer == ordreNummer);

            if (ordre != null)
            {
                // Juster lagerdata for hver vare i ordrelinjerne
                foreach (var ordreLinje in ordre.ordreLinjer)
                {
                    // Brug LagerRepository til at finde varen
                    var vare = await _lagerRepository.GetVareByVarenummerAsync(ordreLinje.vareNummer);
                    if (vare != null)
                    {
                        // Opdater bestiltAntal for varen
                        vare.bestiltAntal = Math.Max((vare.bestiltAntal ?? 0) - (ordreLinje.ordreAntal ?? 0), 0);

                        // Opdater varen i lageret
                        await _lagerRepository.UpdateItemAsync(vare);
                    }
                }

                // Fjern selve ordren
                _context.IndkobsOrdre.Remove(ordre);
                await _context.SaveChangesAsync(); // Gem ændringerne
            }
            else
            {
                throw new KeyNotFoundException($"Ordren med ordreNummer {ordreNummer} blev ikke fundet.");
            }
        }


        public async Task OpdaterBestiltAntalForVarenummerAsync(string varenummer)
        {
            // Hent alle åbne ordrer med ordrelinjer for det givne varenummer
            var ordrerMedVarenummer = await _context.IndkobsOrdre
                .Include(i => i.ordreLinjer)
                .Where(i => i.open && i.ordreLinjer.Any(l => l.vareNummer == varenummer))
                .ToListAsync();

            // Beregn det samlede antal for varenummeret
            var samletAntal = ordrerMedVarenummer
                .SelectMany(o => o.ordreLinjer)
                .Where(l => l.vareNummer == varenummer)
                .Sum(l => l.ordreAntal ?? 0);

            // Hent lagerposten for varenummeret
            var lagerPost = await _lagerRepository.GetVareByVarenummerAsync(varenummer);
            if (lagerPost != null)
            {
                // Opdater lagerets bestilt antal
                lagerPost.bestiltAntal = samletAntal;
                lagerPost.sidsteBestillingsDato = DateTime.Now;

                // Gem opdateringen i lageret
                await _lagerRepository.UpdateItemAsync(lagerPost);
            }
            else
            {
                throw new KeyNotFoundException($"Lagerpost for varenummer {varenummer} blev ikke fundet.");
            }
        }






    }
}

