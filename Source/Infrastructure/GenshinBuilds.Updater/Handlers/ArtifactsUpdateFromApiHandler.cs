using GenshinBuilds.Application.Common.Models;
using GenshinBuilds.Application.Interfaces;
using GenshinBuilds.Application;
using GenshinBuilds.Domain.Models;
using GenshinBuilds.Updater.Handlers.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Updater.Handlers;

public class ArtifactsUpdateFromApiHandler : BaseUpdateHandler<IEnumerable<ArtifactSet>>, IUpdateHandler
{
    public ArtifactsUpdateFromApiHandler
        (IUnitOfWork unitOfWork, IDataProvider<IEnumerable<ArtifactSet>> provider) : base(unitOfWork, provider) { }

    public async Task<UpdateResult> UpdateAsync(bool isDeepUpdate = false)
    {
        var artifactSetFromApi = await base.DataProvider.LoadAsync();
        var artifactRepository = base.UnitOfWork.GetRepository<ArtifactSet>();
        var artifactSetFromDb = await artifactRepository.GetAllAsync();

        var differance = artifactSetFromApi.Except(artifactSetFromDb, new ArtifactsEqualityComparer());

        if (differance.Count() > 0)
        {
            await artifactRepository.InsertRangeAsync(differance);
            await UnitOfWork.Commit();
        }

        return UpdateResult.Create(differance.Count(), "Data has been updated");
    }
}

internal sealed class ArtifactsEqualityComparer : IEqualityComparer<ArtifactSet>
{
    public bool Equals(ArtifactSet? x, ArtifactSet? y)
    {
        return x.Name.Equals(y.Name);
    }

    public int GetHashCode([DisallowNull] ArtifactSet obj)
    {
        return obj.Name.GetHashCode();
    }
}
