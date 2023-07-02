using GenshinBuilds.Application.Common.Converters.Interfaces;
using GenshinBuilds.Application.Common.Resolvers;
using GenshinBuilds.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Application.Common.Converters;

public class StringToElementConverter : ValueConverter, IConverter<string, Element>
{
    public Element Convert(string value)
        => value switch
        {
            string when Contains(value, "geo") => Element.Geo,
            string when Contains(value, "electro") => Element.Electro,
            string when Contains(value, "anemo") => Element.Anemo,
            string when Contains(value, "pyro") => Element.Pyro,
            string when Contains(value, "hydro") => Element.Hydro,
            string when Contains(value, "cryo") => Element.Cryo,
            string when Contains(value, "dendro") => Element.Dendro,
            _ => Element.None
        };
}
