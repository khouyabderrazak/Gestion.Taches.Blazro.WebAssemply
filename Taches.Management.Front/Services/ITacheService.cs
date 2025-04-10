using Taches.Management.Front.Models;

namespace Taches.Management.Front.Services
{
    public interface ITacheService
    {
        Task<TacheModel> Add(TacheModel tache);
        Task<TacheModel> Update(TacheModel tache);
        Task<List<TacheModel>> All(int projectId);
        Task<bool> Delete(int id);
        Task<bool> ChangeStatus(int id);
        Task<TacheModel> GetOne(int id);
    }
}
