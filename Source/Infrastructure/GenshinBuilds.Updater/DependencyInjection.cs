using GenshinBuilds.Application;
using GenshinBuilds.Application.Interfaces;
using GenshinBuilds.Domain.Models;
using GenshinBuilds.Updater.Handlers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Updater;

public static class DependencyInjection
{
    public static IServiceCollection AddUpdater(this IServiceCollection services)
    {
        services.AddScoped<IUpdateHandler, WeaponUpdateFromApiHandler>();
        services.AddScoped<IUpdateHandler, CharacterUpdateFromApiHandler>();
        services.AddScoped<IUpdateHandler, ArtifactsUpdateFromApiHandler>();

        services.AddScoped<IDataUpdateManager, DataUpdateManager>();

        return services;
    }
}
