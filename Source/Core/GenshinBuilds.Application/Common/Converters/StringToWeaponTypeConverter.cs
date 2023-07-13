using GenshinBuilds.Application.Common.Converters.Interfaces;
using GenshinBuilds.Domain;


namespace GenshinBuilds.Application.Common.Resolvers;

public class StringToWeaponTypeConverter : ValueConverter, IConverter<string, WeaponType>
{
    Dictionary<string, WeaponType> languageMappings = new()
        {
            { "polearm", WeaponType.Polearm },
            { "catalyst", WeaponType.Catalyst },
            { "claymore", WeaponType.Claymore },
            { "bow", WeaponType.Bow },
            { "sword", WeaponType.Sword },
            { "древковое", WeaponType.Polearm },
            { "катализатор", WeaponType.Catalyst },
            { "двуручное", WeaponType.Claymore },
            { "стрелковое", WeaponType.Bow },
            { "одноручное", WeaponType.Sword }
        };

    public WeaponType Convert(string value)
    {
        value = value.ToLower();

        if (languageMappings.ContainsKey(value))
        {
            return languageMappings[value];
        }

        return WeaponType.None;
    }
}
