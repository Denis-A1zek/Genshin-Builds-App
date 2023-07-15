using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Domain.Models;

public record CharacterBuild : Identity
{
    public string Title { get; set; }
    public uint Priority { get; set; }
    public List<BuildItem> Characters { get; set; }
}
