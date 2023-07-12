using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Domain.Models;

public record CharacterBuild : Identity
{
    public Character Character { get; set; }
    public Weapon Weapon { get; set; }
    public List<Artifact> Artifacts { get; set; } = new(5);
}
