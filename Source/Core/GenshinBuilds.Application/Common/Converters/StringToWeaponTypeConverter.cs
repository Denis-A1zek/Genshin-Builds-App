using GenshinBuilds.Application.Common.Converters.Interfaces;
using GenshinBuilds.Domain;


namespace GenshinBuilds.Application.Common.Resolvers;

public class StringToWeaponTypeConverter : ValueConverter, IConverter<string, WeaponType>
{
    public WeaponType Convert(string value)
        => value switch
        {
            string when Contains(value, "polearm") => WeaponType.Polearm,
            string when Contains(value, "catalyst") => WeaponType.Catalyst,
            string when Contains(value, "claymore") => WeaponType.Claymore,
            string when Contains(value, "bow") => WeaponType.Bow,
            string when Contains(value, "sword") => WeaponType.Sword,
            _ => WeaponType.None
        };
}
