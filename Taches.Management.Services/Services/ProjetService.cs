using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taches.Management.DAL.Models;
using Taches.Management.DAL.Repositories;
using Taches.Management.Services.Interfaces;
using Taches.Management.Services.Models;

namespace Taches.Management.Services.Services
{
    public class ProjetService(IProjetRepository projetRepository, IMapper _mapper) : IProjetService
    {

        public async Task<ProjetModel> Add(ProjetModel projet)
        {
            var projetToSave = _mapper.Map<Projet>(projet);

            var res = await projetRepository.Add(projetToSave);

            return _mapper.Map<ProjetModel>(res);
        }
        public async Task<List<ProjetModel>> All()
        {
            var projets =  await projetRepository.All();
            return projets.Select(p => _mapper.Map<ProjetModel>(p)).ToList();
        }

        public Task<bool> ChangeStatus(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            return projetRepository.Delete(id);
        }

        public async Task<ProjetModel> GetOne(int id)
        {
            var res = await projetRepository.GetOne(id);
            return _mapper.Map<ProjetModel>(res);
        }
        public async Task<ProjetModel> Update(ProjetModel ProjetModel)
        {
            var projetToUpdate = _mapper.Map<Projet>(ProjetModel);
            var res = await projetRepository.Update(projetToUpdate);

            return _mapper.Map<ProjetModel>(res);
        }


        public async Task OnAnnuler(int ProjetId)
        {
            await projetRepository.OnAnnuler(ProjetId);
        }

        public async Task OnDelancer(int ProjetId)
        {
            await projetRepository.OnDelancer(ProjetId);
        }

        public async Task OnInvalider(int ProjetId)
        {
            await projetRepository.OnInvalider(ProjetId);
        }

        public async Task OnLancer(int ProjetId)
        {
            await projetRepository.OnLancer(ProjetId);
        }

        public async Task OnReCree(int ProjetId)
        {
            await projetRepository.OnReCree(ProjetId);
        }

        public async Task OnValider(int ProjetId)
        {
            await projetRepository.OnValider(ProjetId);
        }



    }
}
