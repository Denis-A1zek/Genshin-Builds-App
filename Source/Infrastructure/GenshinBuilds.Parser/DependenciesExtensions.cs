using GenshinBuilds.Application.Interfaces;
using GenshinBuilds.Domain.Models;
using HtmlAgilityPack;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
