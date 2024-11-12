using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BaggrundsDataLibrary.LagerTransAktioner;
using WindsorX_2027.DB_Entity;

namespace BaggrundsDataLibrary.LagerTransAktioner
{
    public class LagerRepository
    {
        private readonly Entity_Database _context;

        public LagerRepository(Entity_Database context)
        {
            _context = context;
        }

        // Opret en ny transaktion
        public async Task CreateItemAsync(TransaktionerModel item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
        }

        // Hent alle transaktioner
        public async Task<List<TransaktionerModel>> GetAllItemsAsync()
        {
            return await _context.Transaktioner.ToListAsync();
        }

        // Hent en transaktion efter ID
        public async Task<TransaktionerModel?> GetItemByIdAsync(int? id)
        {
            return await _context.Transaktioner.FindAsync(id);
        }

        // Opdater en transaktion
        public async Task UpdateItemAsync(TransaktionerModel item)
        {
            var existingItem = await _context.Transaktioner
                .FirstOrDefaultAsync(x => x.Id == item.Id);

            if (existingItem != null)
            {
                // Map alle nødvendige properties fra 'item' til 'existingItem'
                _context.Entry(existingItem).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Kunne ikke finde transaktionen med ID: " + item.Id);
            }
        }

        // Slet en transaktion
        public async Task DeleteItemAsync(int id)
        {
            var item = await _context.Transaktioner.FindAsync(id);
            if (item != null)
            {
                _context.Transaktioner.Remove(item);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Kunne ikke finde transaktionen med ID: " + id);
            }
        }

        // Kontroller om et varenummer allerede findes i transaktioner
        public async Task<bool> DoesVarenummerExistAsync(string varenummer)
        {
            return await _context.Transaktioner.AnyAsync(v => v.ProduktNummer == varenummer);
        }

        // Søg efter transaktioner med et bestemt varenummer
        public async Task<List<TransaktionerModel>> SoegEfterVarenummer(string varenummer)
        {
            return await _context.Transaktioner
                .Where(p => p.ProduktNummer == varenummer)
                .ToListAsync();
        }
    }
}
