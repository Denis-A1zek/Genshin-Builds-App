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
    Dictionary<string, Element> languageMappings = new()
        {
            { "geo", Element.Geo },
            { "anemo", Element.Anemo },
            { "pyro", Element.Pyro },
            { "hydro", Element.Hydro },
            { "cryo", Element.Cryo },
            { "dendro", Element.Dendro },
            { "electro", Element.Electro },
            { "электро", Element.Electro },
            { "гео", Element.Geo },
            { "анемо", Element.Anemo },
            { "пиро", Element.Pyro },
            { "гидро", Element.Hydro },
            { "крио", Element.Cryo },
            { "дендро", Element.Dendro }
        };

    public Element Convert(string value)
    {
        value = value.ToLower();

        if (languageMappings.ContainsKey(value))
        {
            return languageMappings[value];
        }

        return Element.None;
    }
}
