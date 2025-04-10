using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taches.Management.DAL.Models;

namespace Taches.Management.DAL.Repositories
{
    public interface ITacheRepository
    {
        Task<Tache> Add(Tache tache);
        Task<Tache> Update(Tache tache);
        public Task<List<Tache>> All(int projectId);
        Task<bool> Delete(int id);
        Task<bool> ChangeStatus(int id);
        Task<Tache> GetOne(int id);
    }
}
