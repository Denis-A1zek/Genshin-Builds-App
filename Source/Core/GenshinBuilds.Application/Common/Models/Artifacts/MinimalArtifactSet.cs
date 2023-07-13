using GenshinBuilds.Application.Common.Models.Artifacts;
using GenshinBuilds.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Application.Common.Models
{
    public class MinimalArtifactSet
    {
        public string Name { get; set; }
        public Rarity MaxRarity { get; set; }
        public List<string> Stats { get; set; } = new();
        public List<ArtifactItem> Artifacts { get; set; } = new();
    }
}
