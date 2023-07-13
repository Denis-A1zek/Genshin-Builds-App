using GenshinBuilds.Domain.Enum;
using GenshinBuilds.Domain.Interfaces;

namespace GenshinBuilds.Domain.Models;

public record Artifact : Identity
{
    public string Name { get; set; }    
    public string Description { get; set; }
    public string Story { get; set; }
    public RelicType Type { get; set; }
    public string Image { get; set; }   

}
