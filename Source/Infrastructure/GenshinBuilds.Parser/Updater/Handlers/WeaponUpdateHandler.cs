using GenshinBuilds.Application;
using GenshinBuilds.Application.Common.Models;
using GenshinBuilds.Parser.Updater.Handlers.Base;
using System.Diagnostics.CodeAnalysis;

namespace GenshinBuilds.Parser.Updater.Handlers;

public sealed class WeaponUpdateHandler : BaseUpdateHandler, IUpdateHandler
{
    private readonly IParser<IEnumerable<Weapon>> _weaponParser;

    public WeaponUpdateHandler
        (IUnitOfWork unitOfWork, IParser<IEnumerable<Weapon>> parser) : base(unitOfWork) 
        => (_weaponParser) = (parser);

    public async Task<UpdateResult> UpdateAsync(bool isDeepUpdate = false)
    {
        var parseWeaponsFromPaimonTask = _weaponParser.LoadAsync();
        var repository = UnitOfWork.GetRepository<Weapon>();
        var weaponFromDb = await repository.GetAllAsync();

        var weaponInPaimon = await parseWeaponsFromPaimonTask;

        if (!weaponInPaimon.Any()) return UpdateResult.Create(0, "");
        var differance = weaponInPaimon.Except(weaponFromDb, new WeaponEqualityComparer());
        await repository.InsertRangeAsync(differance);
        await UnitOfWork.Commit();

        return UpdateResult.Create(differance.Count(), "Data has been updated");
    }
}

internal sealed class WeaponEqualityComparer : IEqualityComparer<Weapon>
{
    public bool Equals(Weapon? x, Weapon? y)
    {
        return x.Title.Equals(y.Title);
    }

    public int GetHashCode([DisallowNull] Weapon obj)
    {
        return obj.Title.GetHashCode();
    }
}
