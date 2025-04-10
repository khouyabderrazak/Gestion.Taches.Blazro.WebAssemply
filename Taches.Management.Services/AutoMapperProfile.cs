using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taches.Management.DAL.Models;
using Taches.Management.Services.Models;
using Taches.Management.Services.Models.DTO;

namespace Taches.Management.Services
{
    public class AutoMapperProfile : Profile
    {
          public AutoMapperProfile()
        {
            CreateMap<ApplicationUser, User>().ReverseMap();
            CreateMap<ProjetModel, Projet>().ReverseMap();
            CreateMap<TacheModel, Tache>().ReverseMap();
        }
    }
}
