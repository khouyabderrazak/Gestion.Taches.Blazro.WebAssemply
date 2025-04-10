using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taches.Management.DAL.Data;
using Taches.Management.DAL.Models;
using Taches.Management.DAL.outher;

namespace Taches.Management.DAL.Repositories
{
    public class ProjetRepository(AppDbContext _db) : IProjetRepository
    {
        public async Task<Projet> Add(Projet projet)
        {
            await _db.AddAsync(projet);
            _db.SaveChanges();

            return projet;
        }

        public async Task<List<Projet>> All()
        {
            return await _db.Projets.ToListAsync();
        }

        public Task<bool> ChangeStatus(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            var projet = await _db.Projets.FirstOrDefaultAsync(p => p.Id == id);
            if (projet is null)
                return false;

            _db.Projets.Remove(projet);
            _db.SaveChanges();
            return true;
        }

        public async Task<Projet> GetOne(int id)
        {
            return await _db.Projets.Include(u=> u.Manager).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Projet> Update(Projet projet)
        {
            _db.Projets.Update(projet);
            await _db.SaveChangesAsync();

            return projet;

        }

        public async Task OnAnnuler(int projetId)
        {

            Projet projet = await _db.Projets.FirstOrDefaultAsync(p => p.Id == projetId);
            if (projet != null)
            {
                projet.Statut = ProjetStatus.Annuler;
                _db.Projets.Update(projet);
                await _db.SaveChangesAsync();
            }


        }

        public async Task OnDelancer(int projetId)
        {

            Projet projet = await _db.Projets.FirstOrDefaultAsync(p => p.Id == projetId);
            if (projet != null)
            {
                projet.Statut = ProjetStatus.Creation;
                _db.Projets.Update(projet);
                await _db.SaveChangesAsync();
            }

        }

        public async Task OnInvalider(int projetId)
        {

            Projet projet = await _db.Projets.FirstOrDefaultAsync(p => p.Id == projetId);
            if (projet != null)
            {
                projet.Statut = ProjetStatus.EnCours;
                _db.Projets.Update(projet);
                await _db.SaveChangesAsync();
            }


        }

        public async Task OnLancer(int projetId)
        {
            Projet projet = await _db.Projets.FirstOrDefaultAsync(p => p.Id == projetId);
            if (projet != null)
            {
                projet.Statut = ProjetStatus.EnCours;
                _db.Projets.Update(projet);
                await _db.SaveChangesAsync();
            }
        }

        public async Task OnValider(int projetId)
        {
            Projet projet = await _db.Projets.FirstOrDefaultAsync(p => p.Id == projetId);
            if (projet != null)
            {
                projet.Statut = ProjetStatus.Termine;
                _db.Projets.Update(projet);
                await _db.SaveChangesAsync();
            }
        }
        public async Task OnReCree(int projetId)
        {
            Projet projet = await _db.Projets.FirstOrDefaultAsync(p => p.Id == projetId);
            if (projet != null && projet.Statut != ProjetStatus.Creation)
            {
                projet.Statut = ProjetStatus.Creation;
                _db.Projets.Update(projet);
                await _db.SaveChangesAsync();
            }
        }
    }
}
