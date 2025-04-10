using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taches.Management.DAL.Models;
using Taches.Management.Services.Models;

namespace Taches.Management.Services.Interfaces
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
