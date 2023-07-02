using GenshinBuilds.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GenshinBuilds.Parser;

public static class DependenciesExtensions
{
    public static IServiceCollection AddParsers(this IServiceCollection services)
    {
        services.AddScoped<HtmlWeb>();
        services.AddTransient<IParser<IEnumerable<Weapon>>, WeaponsParser>();
        services.AddTransient<IParser<IEnumerable<Character>>, CharactersParser>();

        return services;
    }
}
