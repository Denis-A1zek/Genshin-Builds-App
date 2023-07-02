using GenshinBuilds.Application.Common.Converters.Interfaces;
using GenshinBuilds.Application.Common.Resolvers;
using GenshinBuilds.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Application.Common.Converters;

public class StringToRarityConverter : ValueConverter, IConverter<string, Rarity>
{
    public Rarity Convert(string value)
        => value switch
        {        
            string when Contains(value, "legendary") => Rarity.Legendary,
            string when Contains(value, "primary") => Rarity.Primary,
            string when Contains(value, "green") => Rarity.Green,
            string when Contains(value, "rare") => Rarity.Rare,
            _ => Rarity.Undefined
        };
}
