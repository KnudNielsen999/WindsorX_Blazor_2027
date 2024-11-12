using WindsorX_2027.LagerModel;

namespace WindsorX_2027.LagerRepositoryMappe
{
    public interface ILagerRepository
    {
        Task CreateItemAsync(Lagermodel item);
        Task DeleteItemAsync(int id);
        Task<bool> DoesVarenummerExistAsync(string varenummer);
        Task<List<Lagermodel>> GetAllItemsAsync();
        Task<Lagermodel?> GetItemByIdAsync(int? id);
        Task<List<Lagermodel>> SoegEfterVarenummer(string varenummer);
        Task UpdateItemAsync(Lagermodel item);
        Task<Lagermodel?> GetVareByVarenummerAsync(string varenummer);
    }
}
