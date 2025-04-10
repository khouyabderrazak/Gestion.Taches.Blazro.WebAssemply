using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Taches.Management.DAL.Data;
using Taches.Management.DAL.Models;
using Taches.Management.DAL.Repositories;

namespace Taches.Management.DAL
{
    public static class DALServices
    {
        public static void AddDALServices(this IServiceCollection services, IConfiguration _config)
        {
            // Configuration du contexte de base de données avec SQL Server
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(_config.GetConnectionString("connectionString"));
            });

            // Configuration de Identity
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
            })
            .AddEntityFrameworkStores<AppDbContext>() 
            .AddDefaultTokenProviders();
            services.AddScoped<IUserStore<ApplicationUser>, UserStore<ApplicationUser, IdentityRole, AppDbContext>>();


            services.AddScoped<IProjetRepository, ProjetRepository>();
            services.AddScoped<ITacheRepository, TacheRepository>();


        }
    }
}
