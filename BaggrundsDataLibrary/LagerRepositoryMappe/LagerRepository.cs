namespace WindsorX_2027.LagerRepositoryMappe
{
    using Microsoft.EntityFrameworkCore;
    using WindsorX_2027.DB_Entity;
    using WindsorX_2027.IndkoebsModel;
    using WindsorX_2027.LagerModel;

    public class LagerRepository : ILagerRepository
    {
        private readonly Entity_Database _context;

        public LagerRepository(Entity_Database context)
        {
            _context = context;
        }

        // Opret et nyt varenummer
        public async Task CreateItemAsync(Lagermodel item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Lagermodel?> GetVareByVarenummerAsync(string varenummer)
        {
            return await _context.LagerData.FirstOrDefaultAsync(v => v.vareNummer == varenummer);
        }

        // Hent alle varenumre
        public async Task<List<Lagermodel>> GetAllItemsAsync()
        {
            return await _context.LagerData.ToListAsync();
        }

        // Hent et varenummer efter ID
        public async Task<Lagermodel?> GetItemByIdAsync(int? id)
        {
            return await _context.LagerData.FindAsync(id);
        }

        // Opdater et varenummer
        public async Task UpdateItemAsync(Lagermodel item)
        {
            var existingItem = await _context.LagerData
                .FirstOrDefaultAsync(x => x.Id == item.Id);

            if (existingItem != null)
            {
                // Map alle nødvendige properties fra 'item' til 'existingItem'
                _context.Entry(existingItem).CurrentValues.SetValues(item);

                // Hvis du har navigation properties som skal opdateres, gør det her
                // F.eks.: existingItem.RelatedEntity = item.RelatedEntity;

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Kunne ikke finde varen med ID: " + item.Id);
            }
        }


        // Slet et varenummer
        public async Task DeleteItemAsync(int id)
        {
            var item = await _context.LagerData.FindAsync(id);
            _context.LagerData.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DoesVarenummerExistAsync(string varenummer)
        {
            return await _context.LagerData.AnyAsync(v => v.vareNummer == varenummer);
        }

        public async Task<List<Lagermodel>> SoegEfterVarenummer(string varenummer)
        {
            var data = await _context.LagerData.ToListAsync();
            return data.Where(p => p.vareNummer == varenummer).ToList();
        }

       


    }
}
  
