using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taches.Management.DAL.Models;
using Taches.Management.DAL.Repositories;
using Taches.Management.Services.Models;

namespace Taches.Management.Services.Interfaces
{
    public class TacheService(ITacheRepository tacheRepository,IMapper _mapper) : ITacheService
    {
        public async Task<TacheModel> Add(TacheModel tache)
        {
            var tacheToSave = _mapper.Map<Tache>(tache);
             var ress= await tacheRepository.Add(tacheToSave);

            return _mapper.Map<TacheModel>(ress);
        }

        public async Task<List<TacheModel>> All(int projectId)
        {
            var taches = await tacheRepository.All(projectId);
            return taches.Select(t => _mapper.Map<TacheModel>(t)).ToList();
        }

        public Task<bool> ChangeStatus(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            return await tacheRepository.Delete(id);
        }

        public async Task<TacheModel> GetOne(int id)
        {
            var tache = await tacheRepository.GetOne(id);
            return _mapper.Map<TacheModel>(tache);
        }

        public async Task<TacheModel> Update(TacheModel tache)
        {
            var tacheToSave = _mapper.Map<Tache>(tache);
            var ress = await tacheRepository.Update(tacheToSave);
            return _mapper.Map<TacheModel>(ress);
        }
    }
}
