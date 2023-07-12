using GenshinBuilds.Domain.Interfaces;


namespace GenshinBuilds.Domain.Models;

public record ArtifactSet : Identity, IUpdateble
{
    public string Title { get; set; }
    public Rarity MaxRarity { get; set; }
    public string Description { get; set; }
    public List<Artifact> Artifacts { get; set; } = new List<Artifact>(5);
}
