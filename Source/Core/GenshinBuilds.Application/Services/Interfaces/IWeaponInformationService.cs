using GenshinBuilds.Application.Common.Models;
using GenshinBuilds.Domain.Models.Common;

namespace GenshinBuilds.Application.Services.Interfaces;

public interface IWeaponInformationService
{
    Task<IEnumerable<MinimalWeapon>> GetAllMinimalWeaponInfo();
    Task<DetailedWeapon> GetDetailedWeaponInfoById(Identity id);
}
