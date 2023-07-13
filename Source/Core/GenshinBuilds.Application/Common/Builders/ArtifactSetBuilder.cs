using GenshinBuilds.Domain;
using GenshinBuilds.Domain.Interfaces;
using GenshinBuilds.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Application.Common.Builders;

public sealed class ArtifactSetBuilder : IArtifactSetBuilder
{
    private ArtifactSet _artifact;
    private readonly IValueConverter _converter;

    public ArtifactSetBuilder(IValueConverter converter)
        => (_converter) = (converter);
    public IArtifactSetBuilder AddArtifact(Artifact artifact)
    {
        _artifact.Artifacts.Add(artifact);
        return this;
    }

    public ArtifactSet Build()
    {
        var buildedArtifactSet = _artifact;
        _artifact = null;
        return buildedArtifactSet;
    }

    public IArtifactSetBuilder Create()
    {
        _artifact = new();
        _artifact.Artifacts = new(5);
        return this;
    }

    public IArtifactSetBuilder SetName(string name)
    {
        _artifact.Name = name;
        return this;
    }

    public IArtifactSetBuilder AddRarity(IReadOnlyList<string> rarity)
    {
        return this;
    }

    public IArtifactSetBuilder SetRarity(Rarity rarity)
    {
        _artifact.MaxRarity = rarity;
        return this;
    }

    public IArtifactSetBuilder AddStats(string[] stats)
    {
        _artifact.Stats.AddRange(stats);
        return this;
    }

    public IArtifactSetBuilder SetArtifact(List<Artifact> artifact)
    {
        foreach(var item in artifact)
        {
            AddArtifact(item);
        }
        return this;
    }
}
