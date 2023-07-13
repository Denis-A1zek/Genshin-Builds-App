using GenshinBuilds.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Application.Common.Models.Artifacts;

public class ArtifactItem
{
    public string Name { get; set; }
    public RelicType Type { get; set; }
    public string Image { get; set; }   
}
