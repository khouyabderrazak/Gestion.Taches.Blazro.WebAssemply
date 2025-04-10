using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taches.Management.DAL.Models;
using Taches.Management.Services.Models;

namespace Taches.Management.Services.Interfaces
{
    public interface IProjetService
    {
        Task<ProjetModel> Add(ProjetModel projet);
        Task<ProjetModel> Update(ProjetModel ProjetModel);
        Task<List<ProjetModel>> All();
        Task<bool> Delete(int id);
        Task<bool> ChangeStatus(int id);
        public Task<ProjetModel> GetOne(int id);
        Task OnLancer(int ProjetId);
        Task OnAnnuler(int ProjetId);
        Task OnDelancer(int ProjetId);
        Task OnValider(int ProjetId);
        Task OnInvalider(int ProjetId);

        Task OnReCree(int ProjetId);
    }
}
