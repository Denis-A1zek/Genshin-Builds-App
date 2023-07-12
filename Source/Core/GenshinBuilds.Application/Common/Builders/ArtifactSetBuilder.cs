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

    public IArtifactSetBuilder SetDescription(string description)
    {
        _artifact.Description = description;
        return this;
    }

    public IArtifactSetBuilder SetRarity(string rarity)
    {
        SetRarity(_converter.Convert<string, Rarity>(rarity));
        return this;
    }

    public IArtifactSetBuilder SetRarity(Rarity rarity)
    {
        _artifact.MaxRarity = rarity;
        return this;
    }

    public IArtifactSetBuilder SetTitle(string title)
    {
        _artifact.Title = title;
        return this;
    }
}
