using GenshinBuilds.Application;
using GenshinBuilds.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.RelationalDb
{
    public static class DependenciesExtensions
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(options => options.UseSqlite("Data Source=NotesDb.db"));
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            return services;
        }
    }
}
