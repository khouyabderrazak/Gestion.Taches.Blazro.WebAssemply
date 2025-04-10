
using Taches.Management.Front.Models;

namespace Taches.Management.Front.Services
{
    public interface IProjetService
    {
        Task<ProjetModel> Add(ProjetModel projet);
        Task<ProjetModel> Update(ProjetModel ProjetModel);
        Task<List<ProjetModel>> All();
        Task<bool> Delete(int id);
        Task<bool> ChangeStatus(int id);
        Task<ProjetModel> GetOne(int id);
        Task OnLancer(int ProjetId);
        Task OnAnnuler(int ProjetId);
        Task OnDelancer(int ProjetId);
        Task OnValider(int ProjetId);
        Task OnInvalider(int ProjetId);

        Task OnReCree(int ProjetId);
    }
}
