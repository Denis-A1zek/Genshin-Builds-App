using GenshinBuilds.Domain.Enum;

namespace GenshinBuilds.Parser.Helpers;

internal static class ItemHelper
{
    public static WeaponType GetWeaponType(string type)
        => type.ToLower() switch
        {
            "polearm" => WeaponType.Polearm,
            "catalyst" => WeaponType.Catalyst,
            "claymore" => WeaponType.Claymore,
            "bow" => WeaponType.Bow,
            "sword" => WeaponType.Sword,
            _ => WeaponType.None
        };

    public static Rarity GetRarity(string value)
    => value switch
    {
        string r when value.Contains("rare", StringComparison.InvariantCultureIgnoreCase) => Rarity.Rare,
        string r when value.Contains("legendary", StringComparison.InvariantCultureIgnoreCase) => Rarity.Legendary,
        string r when value.Contains("primary", StringComparison.InvariantCultureIgnoreCase) => Rarity.Primary,
        string r when value.Contains("green", StringComparison.InvariantCultureIgnoreCase) => Rarity.Green,
        _ => Rarity.Undefined
    };

    public static Element GetElement(string value)
        => value switch
        {
            string r when value.Contains("geo", StringComparison.InvariantCultureIgnoreCase) => Element.Geo,
            string r when value.Contains("electro", StringComparison.InvariantCultureIgnoreCase) => Element.Electro,
            string r when value.Contains("anemo", StringComparison.InvariantCultureIgnoreCase) => Element.Anemo,
            string r when value.Contains("pyro", StringComparison.InvariantCultureIgnoreCase) => Element.Pyro,
            string r when value.Contains("hydro", StringComparison.InvariantCultureIgnoreCase) => Element.Hydro,
            string r when value.Contains("cryo", StringComparison.InvariantCultureIgnoreCase) => Element.Cryo,
            string r when value.Contains("dendro", StringComparison.InvariantCultureIgnoreCase) => Element.Dendro,
            _ => Element.None
        };
}
