using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taches.Management.DAL.Data;
using Taches.Management.DAL.Models;

namespace Taches.Management.DAL.Repositories
{
    public class TacheRepository(AppDbContext _db) : ITacheRepository
    {
        public async Task<Tache> Add(Tache tache)
        {
            await _db.Taches.AddAsync(tache);
            _db.SaveChanges();

            return tache;
        }

        public async Task<List<Tache>> All(int projectId)
        {
            var taches = await _db.Taches.Include(p => p.Projet).Where(t => t.ProjetId == projectId).ToListAsync();

            return taches;
        }

        public Task<bool> ChangeStatus(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            var tache = await _db.Taches.FirstOrDefaultAsync(t=> t.Id == id);
            if (tache is null)
                return false;

            _db.Taches.Remove(tache);

            _db.SaveChanges();

            return true;
        }

        public async Task<Tache> GetOne(int id)
        {
            return await _db.Taches.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Tache> Update(Tache tache)
        {
             _db.Taches.Update(tache);
             await _db.SaveChangesAsync();

            return tache;
        }
    }
}
