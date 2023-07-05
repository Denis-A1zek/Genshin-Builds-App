using GenshinBuilds.Application.Common.Builders;
using GenshinBuilds.Application.Common.Resolvers;
using GenshinBuilds.Domain;
using GenshinBuilds.Domain.Builders;
using Microsoft.Extensions.DependencyInjection;


namespace GenshinBuilds.Application;

public static class DependencyInjection
{
    public static IServiceCollection LoadApplicationDependency(this IServiceCollection services)
    {
        services.AddTransient<IWeaponBuilder, WeaponBuilder>();

        services.AddSingleton<IValueConverter>(new ValueConverter(options =>
        {
            options.RegisterConverter(new StringToWeaponTypeConverter());
        }));

        return services;
    }
}
