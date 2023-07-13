using GenshinBuilds.Application.Common.Models;
using GenshinBuilds.Application.Services.Interfaces;
using GenshinBuilds.Domain.Models;
using GenshinBuilds.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Application.Services.Implementation
{
    public class CharacterInformationService : ICharacterInformationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CharacterInformationService(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;


        public async Task<IEnumerable<MinimalCharacter>> GetAllMinimalCharacterInfo()
        {
            var reposiory = _unitOfWork.GetRepository<Character>();
            var characters = await reposiory.GetAllAsync();
            var minimalCharacter = characters
                .Select(w =>
                new MinimalCharacter()
                {
                    Id = w.Id,
                    Name = string.IsNullOrEmpty(w.Name) ? "Путешествинница" : w.FullName,
                    WeaponType = w.WeaponType,
                    Rarity = w.Rarity,
                    Avatar = w.Avatar,
                    Element = w.Element,
                });

            return minimalCharacter;
        }

        public Task<DetailedCharacter> GetDetailedCharacterInfoById(Identity id)
        {
            throw new NotImplementedException();
        }
    }
}
