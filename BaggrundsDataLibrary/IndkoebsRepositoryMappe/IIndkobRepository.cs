using WindsorX_2027.IndkoebsModel;

namespace WindsorX_2027.IndkoebsRepositoryMappe
{
    public interface IIndkobRepository
    {
        Task CreateIndkobAsync(IndkobModel indkob);
        Task DeleteIndkobAsync(int id);
        Task<bool> DoesOrdreNummerExistAsync(string ordreNummer);
        Task<List<IndkobModel>> GetAllIndkobAsync();
        Task<IndkobModel> GetIndkobByIdAsync(int id);
        Task<List<IndkobModel>> SearchByOrdreNummerAsync(string ordreNummer);
        Task UpdateIndkobAsync(IndkobModel indkob);
        Task<IndkobModel?> GetIndkobByOrdreNummerAsync(string ordreNummer);
        Task<List<IndkobModel?>> GetOpenIndkobsAsync();
        Task CloseOrderAsync(string ordreNummer);
        Task DeleteOrderAsync(string ordreNummer);
    }
}