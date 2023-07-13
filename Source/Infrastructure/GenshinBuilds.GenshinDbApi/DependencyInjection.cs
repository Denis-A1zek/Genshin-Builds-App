using GenshinBuilds.Application.Interfaces;
using GenshinBuilds.Application;
using GenshinBuilds.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using GenshinBuilds.GenshinDbApi.Providers;

namespace GenshinBuilds.GenshinDbApi;

public static class DependencyInjection
{
    public static IServiceCollection AddApiCalls(this IServiceCollection services)
    {
        services.AddScoped<HttpClient>();

        services.AddTransient<IDataProvider<IEnumerable<Weapon>>, WeaponsProvider>();
        services.AddTransient<IDataProvider<IEnumerable<Character>>, CharactersProvider>();
        services.AddTransient<IDataProvider<IEnumerable<ArtifactSet>>, ArtifactsSetProvider>();

        return services;
    }
}
