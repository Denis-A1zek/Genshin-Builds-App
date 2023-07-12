using GenshinBuilds.Domain.Enum;
using GenshinBuilds.Domain.Interfaces;

namespace GenshinBuilds.Domain.Models;

public record Artifact : Identity
{
    public ArtifactType Type { get; set; }
    public string ImageUrl { get; set; }
}
