using GenshinBuilds.Application;
using GenshinBuilds.Domain;
using GenshinBuilds.Domain.Enum;
using GenshinBuilds.Domain.Interfaces;
using GenshinBuilds.Domain.Models;
using GenshinBuilds.GenshinDbApi.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.GenshinDbApi.Providers;

public class ArtifactsSetProvider : BaseProvider<IEnumerable<ArtifactSet>>
{
    private readonly IArtifactSetBuilder _builder;
    private readonly IValueConverter _valueConverter;
    public ArtifactsSetProvider
        (HttpClient httpClient, IArtifactSetBuilder artifactSetBuilder, IValueConverter valueConverter) : base(httpClient)
        => (_builder, _valueConverter) = (artifactSetBuilder, valueConverter);

    protected internal override string Url => ApiUrlConstants.ArtifactApiUrl;

    public override async Task<IEnumerable<ArtifactSet>> LoadAsync()
    {
        var artifactResult = await GetResponseAsync<ArtifactResponse>();

        var artifactSet = artifactResult.Result.Select(a =>
            _builder.Create()
            .SetName(a.Name)
            .AddStats(GetValidStats(a))
            .SetRarity((Rarity)int.Parse(a.Rarity.Max()))
            .SetArtifact(CreateArtifact(a, a.Sands, a.Circlet, a.Flower, a.Goblet, a.Plume))
            .Build());

        return artifactSet;
    }

    private string[] GetValidStats(ArtifactResponse artifact)
    {
        var listStats = new List<string>();
        if (artifact._1pc is not null)
        {
            listStats.Add(artifact._1pc);
            return listStats.ToArray();
        }
        listStats.Add(artifact._2pc);
        listStats.Add(artifact._4pc);
        return listStats.ToArray();
    }

    private List<Artifact> CreateArtifact(ArtifactResponse source ,params ArtifactDetails[] artifactDetails)
    {
        List<Artifact> list = new List<Artifact>();

        foreach (var artifact in artifactDetails.Where(s => s is not null))
        {
            var art = new Artifact()
            {
                Description = artifact.Description,
                Name = artifact.Name,
                Story = artifact.Story,
                Type = _valueConverter.Convert<string, RelicType>(artifact.Relictype),
                Image = GetRelicImgeByType(_valueConverter.Convert<string, RelicType>(artifact.Relictype), source)
            };
            list.Add(art);
        }

        return list;
    }

    private string GetRelicImgeByType(RelicType type, ArtifactResponse source)
    {
        Dictionary<RelicType, string> nameImage = new()
        {
            { RelicType.Flower, source.Images.Flower },
            { RelicType.Circlet, source.Images.Circlet },
            { RelicType.Goblet, source.Images.Goblet },
            { RelicType.Plume, source.Images.Plume },
            { RelicType.Sands, source.Images.Sands }
        };

        if(nameImage.ContainsKey(type))
            return nameImage[type];

        return "";
    }
}
