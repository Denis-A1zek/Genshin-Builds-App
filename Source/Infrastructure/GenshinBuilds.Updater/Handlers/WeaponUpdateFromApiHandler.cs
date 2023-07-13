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

namespace GenshinBuilds.Updater.Handlers
{
    public class WeaponUpdateFromApiHandler : BaseUpdateHandler<IEnumerable<Weapon>>, IUpdateHandler
    {
        public WeaponUpdateFromApiHandler
            (IUnitOfWork unitOfWork, IDataProvider<IEnumerable<Weapon>> provider) : base(unitOfWork, provider) { }

        public async Task<UpdateResult> UpdateAsync(bool isDeepUpdate = false)
        {
            var weaponsFromApi = await base.DataProvider.LoadAsync();
            var weaponsRepository = base.UnitOfWork.GetRepository<Weapon>();
            var weaponsFromDb = await weaponsRepository.GetAllAsync();

            var differance = weaponsFromApi.Except(weaponsFromDb, new WeaponEqualityComparer());

            if (differance.Count() > 0)
            {
                await weaponsRepository.InsertRangeAsync(differance);
                await UnitOfWork.Commit();
            }

            return UpdateResult.Create(differance.Count(), "Data has been updated");
        }
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
