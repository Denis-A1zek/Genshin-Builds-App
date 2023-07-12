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
    public IArtifactSetBuilder SetTitle(string title);
    public IArtifactSetBuilder SetDescription(string description);
    public IArtifactSetBuilder SetRarity(string rarity);
    public IArtifactSetBuilder SetRarity(Rarity rarity);
    public IArtifactSetBuilder AddArtifact(Artifact artifact);
    public ArtifactSet Build();
}
