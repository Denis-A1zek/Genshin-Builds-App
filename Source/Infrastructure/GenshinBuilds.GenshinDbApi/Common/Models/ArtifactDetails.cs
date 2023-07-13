using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.GenshinDbApi.Common.Models
{
    internal record ArtifactDetails(
         string Name,
         string Relictype,
         string Description,
         string Story
    );
}
