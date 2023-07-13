using GenshinBuilds.Application.Common.Models;
using GenshinBuilds.Application.Services.Interfaces;
using GenshinBuilds.Domain.Models;
using GenshinBuilds.Domain.Models.Common;

namespace GenshinBuilds.Application.Services.Implementation
{
    public class WeaponInformationService : IWeaponInformationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public WeaponInformationService(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public async Task<IEnumerable<MinimalWeapon>> GetAllMinimalWeaponInfo()
        {
            var reposiory = _unitOfWork.GetRepository<Weapon>();
            var weapons = await reposiory.GetAllAsync();
            var minimalWeapon = weapons
                .Select(w =>
                new MinimalWeapon()
                {
                    Id = w.Id,
                    Name = w.Title,
                    Description = w.Description,
                    Rarity = w.Rarity,
                    WeaponType = w.WeaponType,
                    Image = w.Image
                });

            return minimalWeapon;
        }

        public Task<DetailedWeapon> GetDetailedWeaponInfoById(Identity id)
        {
            throw new NotImplementedException();
        }
    }
}
