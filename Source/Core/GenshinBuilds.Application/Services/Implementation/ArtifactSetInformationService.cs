using GenshinBuilds.Application.Common.Models;
using GenshinBuilds.Application.Common.Models.Artifacts;
using GenshinBuilds.Application.Services.Interfaces;
using GenshinBuilds.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Application.Services.Implementation;

public class ArtifactSetInformationService : IArtifactSetInformationService
{
    private readonly IUnitOfWork _unitOfWork;

    public ArtifactSetInformationService(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task<IEnumerable<MinimalArtifactSet>> GetAllMinimalArtifactSetInfo()
    {
        var repositpry = _unitOfWork.GetRepository<ArtifactSet>();
        var artifactSetFromDb = await repositpry.Include(s => s.Artifacts);
        if (!artifactSetFromDb.Any()) throw new Exception("GetAllMinimalArtifactSetInfo error | DbNotInit or Empty");
        List<MinimalArtifactSet> minimalArtifactSet = new();

        foreach (var artifactSet in artifactSetFromDb)
        {
            var minimalSet = new MinimalArtifactSet()
            {
                Name = artifactSet.Name,
                MaxRarity = artifactSet.MaxRarity,
                Stats = artifactSet.Stats,
                Artifacts = GenerateArtifactItemsFromSet(artifactSet),

            };
            minimalArtifactSet.Add(minimalSet);
        }

        return minimalArtifactSet;
    }

    public Task<MinimalArtifact> GetAllMinmialArtifactInfo()
    {
        throw new NotImplementedException();
    }

    private List<ArtifactItem> GenerateArtifactItemsFromSet(ArtifactSet artifactSet)
    {
        List<ArtifactItem> artifactItems = new();
        foreach (var item in artifactSet.Artifacts) 
        {
            artifactItems.Add(new ArtifactItem()
            {
                Name = item.Name,
                Image = item.Image,
                Type = item.Type
            });
        }

        return artifactItems;   
    }
}
