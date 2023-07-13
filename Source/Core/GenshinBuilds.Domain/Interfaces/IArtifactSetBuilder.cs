using GenshinBuilds.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Domain.Interfaces;

public interface IArtifactSetBuilder
{
    public IArtifactSetBuilder Create();
    public IArtifactSetBuilder SetName(string name);
    public IArtifactSetBuilder AddRarity(IReadOnlyList<string> rarity);
    public IArtifactSetBuilder SetRarity(Rarity rarity);
    public IArtifactSetBuilder AddStats(string[] stats);
    public IArtifactSetBuilder AddArtifact(Artifact artifact);
    public IArtifactSetBuilder SetArtifact(List<Artifact> artifact);
    public ArtifactSet Build();
}
