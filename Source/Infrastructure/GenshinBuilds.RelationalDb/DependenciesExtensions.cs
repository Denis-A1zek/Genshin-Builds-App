using GenshinBuilds.Application;
using GenshinBuilds.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GenshinBuilds.RelationalDb
{
    public static class DependenciesExtensions
    {
        public static IServiceCollection AddRepository
            (this IServiceCollection services, IConfiguration configuration)
        {

            var connectionString = configuration.GetConnectionString(nameof(DatabaseContext));
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlite(connectionString);
            });

           
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}

