using GenshinBuilds.Application.Common.Builders;
using GenshinBuilds.Application.Common.Converters;
using GenshinBuilds.Application.Common.Resolvers;
using GenshinBuilds.Application.Services.Implementation;
using GenshinBuilds.Application.Services.Interfaces;
using GenshinBuilds.Domain;
using GenshinBuilds.Domain.Builders;
using GenshinBuilds.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;


namespace GenshinBuilds.Application;

public static class DependencyInjection
{
    public static IServiceCollection LoadApplicationDependency(this IServiceCollection services)
    {
        services.AddTransient<IWeaponBuilder, WeaponBuilder>();
        services.AddTransient<ICharacterBuilder, CharacterBuilder>();
        services.AddTransient<IArtifactSetBuilder, ArtifactSetBuilder>();

        services.AddScoped<IWeaponInformationService, WeaponInformationService>();
        services.AddScoped<ICharacterInformationService, CharacterInformationService>();
        services.AddScoped<IArtifactSetInformationService, ArtifactSetInformationService>();

        services.AddSingleton<IValueConverter>(new ValueConverter(options =>
        {
            options.RegisterConverter(new StringToWeaponTypeConverter());
            options.RegisterConverter(new StringToElementConverter());
            options.RegisterConverter(new StringToRarityConverter());
            options.RegisterConverter(new StringToRelicTypeConverter());
        }));

        return services;
    }
}
