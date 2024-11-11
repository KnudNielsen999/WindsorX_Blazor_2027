namespace WindsorX_2027.IndkoebsRepositoryMappe
{
    using Microsoft.EntityFrameworkCore;
    using WindsorX_2027.DB_Entity;
    using WindsorX_2027.IndkoebsModel;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class IndkobRepository : IIndkobRepository
    {
        private readonly Entity_Database _context;

        public IndkobRepository(Entity_Database context)
        {
            _context = context;
        }

        // Opret en ny indkøbsordre
        public async Task CreateIndkobAsync(IndkobModel indkob)
        {
            _context.Attach(indkob);
            _context.Add(indkob);
            await _context.SaveChangesAsync();
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
            var existingIndkob = await _context.IndkobsOrdre
                .Include(i => i.ordreLinjer) // Inkluderer ordrelinjer for korrekt opdatering
                .FirstOrDefaultAsync(i => i.Id == indkob.Id);

            if (existingIndkob != null)
            {
                // Map alle nødvendige properties fra 'indkob' til 'existingIndkob'
                _context.Entry(existingIndkob).CurrentValues.SetValues(indkob);

                // Opdater ordrelinjer
                existingIndkob.ordreLinjer.Clear();
                existingIndkob.ordreLinjer.AddRange(indkob.ordreLinjer);

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Kunne ikke finde indkøbsordren med ID: " + indkob.Id);
            }
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
    }
}

