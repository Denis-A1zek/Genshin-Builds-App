using GenshinBuilds.Application;
using GenshinBuilds.Application.Interfaces;
using GenshinBuilds.Domain.Models;
using GenshinBuilds.Parser.Updater;
using GenshinBuilds.Parser.Updater.Checkers;
using GenshinBuilds.Parser.Updater.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace GenshinBuilds.Parser;

public static class DependenciesExtensions
{
    public static IServiceCollection AddParsers(this IServiceCollection services)
    {
        services.AddScoped<HtmlWeb>();
        
        services.AddTransient<IParser<IEnumerable<Weapon>>, WeaponsParser>();
        services.AddTransient<IParser<IEnumerable<Character>>, CharactersParser>();

        services.AddScoped<IUpdateChecker, WeaponUpdateChecker>();
        services.AddScoped<IUpdateChecker, CharacterUpdateChecker>();

        services.AddScoped<IUpdateHandler, WeaponUpdateHandler>();
        services.AddScoped<IUpdateHandler, CharacterUpdateHandler>();

        services.AddScoped<IDataUpdateManagerParser, DataUpdateManager>();

        return services;
    }
}
