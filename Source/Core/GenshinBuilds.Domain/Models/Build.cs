using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Domain.Models;

public record Build : Identity
{
    public string Title { get; set; }
    public DateTime Created { get; set; }
    public List<CharacterBuild> Character { get; set; } = new(4);
}
