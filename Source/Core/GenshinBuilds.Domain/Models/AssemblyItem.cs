using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Domain.Models;

public record AssemblyItem : Identity
{
    public Guid CharacterId { get; set; }
    public Guid WeaponId { get; set; }
    public List<ArtifactInfo> Artifacts { get; set; } = new();
}
