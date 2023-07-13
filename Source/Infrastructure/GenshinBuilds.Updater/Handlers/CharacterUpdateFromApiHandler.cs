using GenshinBuilds.Application;
using GenshinBuilds.Application.Common.Models;
using GenshinBuilds.Application.Interfaces;
using GenshinBuilds.Domain.Models;
using GenshinBuilds.Updater.Handlers.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Updater.Handlers;

public class CharacterUpdateFromApiHandler : BaseUpdateHandler<IEnumerable<Character>>, IUpdateHandler
{
    public CharacterUpdateFromApiHandler
        (IUnitOfWork unitOfWork, IDataProvider<IEnumerable<Character>> provider) : base(unitOfWork, provider) { }

    public async Task<UpdateResult> UpdateAsync(bool isDeepUpdate = false)
    {
        var charactersFromApi = await base.DataProvider.LoadAsync();
        var charactersRepository = base.UnitOfWork.GetRepository<Character>();
        var charactersFromDb = await charactersRepository.GetAllAsync();

        var differance = charactersFromApi.Except(charactersFromDb, new CharacterEqualityComparer());

        if(differance.Count() > 0 )
        {
            await charactersRepository.InsertRangeAsync(differance);
            await UnitOfWork.Commit();
        }

        return UpdateResult.Create(differance.Count(), "Data has been updated");
    }
}

internal sealed class CharacterEqualityComparer : IEqualityComparer<Character>
{
    public bool Equals(Character? x, Character? y)
    {
        return x.Name.Equals(y.Name);
    }

    public int GetHashCode([DisallowNull] Character obj)
    {
        return obj.Name.GetHashCode();
    }
}