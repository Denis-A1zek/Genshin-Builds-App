using GenshinBuilds.Domain.Interfaces;


namespace GenshinBuilds.Domain.Models;

public record ArtifactSet : Identity
{
    public string Name { get; set; }
    public Rarity MaxRarity { get; set; }
    public List<string> Stats { get; set; } = new(3);
    public List<Artifact> Artifacts { get; set; } = new List<Artifact>(5);
}
