using GenshinBuilds.Domain;

namespace GenshinBuilds.ElectronBlazor.Common.Helpers
{
    public static class RarityCssStyleHelper
    {
        public static readonly Dictionary<Rarity, string> BackgroundGradient = new()
        {
            { Rarity.Rare, "background: linear-gradient(132deg, rgba(106,84,83,1) 0%, rgba(217,163,80,1) 100%);"},
            { Rarity.Legendary, "background: linear-gradient(132deg, rgba(91,85,130,1) 0%, rgba(178,131,197,1) 100%);"},
            { Rarity.Primary, "background: linear-gradient(132deg, rgba(81,84,116,1) 0%, rgba(74,152,174,1) 100%);"},
            { Rarity.Green, "background: linear-gradient(132deg, rgba(73,88,93,1) 0%, rgba(91,143,107,1) 100%);"},
            { Rarity.Undefined, "background: linear-gradient(132deg, rgba(78,88,100,1) 0%, rgba(125,135,148,1) 100%);"}
        };

        public static readonly Dictionary<Rarity, string> StarColor = new()
        {
            { Rarity.Undefined, "#FFFFFF"}, {Rarity.Green , "#65CD8D"}, {Rarity.Primary, "#4C79F8" }, {Rarity.Legendary , "#CB8BCF"}, {Rarity.Rare, "#FFB13F"}
        };
    }
}
