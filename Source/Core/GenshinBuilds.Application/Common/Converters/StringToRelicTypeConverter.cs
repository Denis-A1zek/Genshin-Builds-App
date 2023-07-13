using GenshinBuilds.Application.Common.Converters.Interfaces;
using GenshinBuilds.Application.Common.Resolvers;
using GenshinBuilds.Domain;
using GenshinBuilds.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Application.Common.Converters;

public class StringToRelicTypeConverter : ValueConverter, IConverter<string, RelicType>
{
    public RelicType Convert(string value)
        => value switch
        {
            string when Contains(value, "Перо смерти") => RelicType.Plume,
            string when Contains(value, "Корона разума") => RelicType.Circlet,
            string when Contains(value, "Цветок жизни") => RelicType.Flower,
            string when Contains(value, "Пески времени") => RelicType.Sands,
            _ => RelicType.Goblet
        };
}
