using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace GenshinBuilds.GenshinDbApi.Common.Models
{
    internal record ArtifactResponse(
         string Name,
         IReadOnlyList<string> Rarity,
        [property: JsonPropertyName("2pc")] string _2pc,
        [property: JsonPropertyName("4pc")] string _4pc,
         ArtifactDetails Flower,
         ArtifactDetails Plume,
         ArtifactDetails Sands,
         ArtifactDetails Goblet,
         ArtifactDetails Circlet,
         ArtifactImages Images,
         string Version,
        [property: JsonPropertyName("1pc")] string _1pc
    );
}
