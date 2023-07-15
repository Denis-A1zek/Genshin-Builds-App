using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Domain.Models;

public record BuildItem : Identity
{
    public Guid CharacterId { get; set; }
    public Character Character { get; set; }
    public Guid EquippedWeaponId { get; set; }
    public Weapon EquippedWeapon { get; set; }

    public List<ArtifactStats> EquippedArtifacts = new();
}
