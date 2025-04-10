using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Taches.Management.DAL;
using Taches.Management.DAL.Repositories;
using Taches.Management.Services.Interfaces;
using Taches.Management.Services.Services;

namespace Taches.Management.Services
{
    public static class BALServices
    {
        public static void AddBALServices(this IServiceCollection services, IConfiguration _config)
        {
            services.AddDALServices(_config);
            services.AddScoped<IUser, UserService>();
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddScoped<IProjetService, ProjetService>();
            services.AddScoped<ITacheService, TacheService>();
        }
    }
}
