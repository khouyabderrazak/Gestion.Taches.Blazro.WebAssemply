using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taches.Management.DAL.Models;

namespace Taches.Management.DAL.Repositories
{
    public interface IProjetRepository
    {
        Task<Projet> Add(Projet projet);
        Task<Projet> Update(Projet projet);
        Task<List<Projet>> All();
        Task<bool> Delete(int id);
        Task<bool> ChangeStatus(int id);

        Task<Projet> GetOne(int id);
        Task OnLancer(int ProjetId);
        Task OnAnnuler(int ProjetId);
        Task OnDelancer(int ProjetId);
        Task OnValider(int ProjetId);
        Task OnInvalider(int ProjetId);

        Task OnReCree(int ProjetId);
    }
}
