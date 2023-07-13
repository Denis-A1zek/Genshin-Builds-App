using GenshinBuilds.Application.Common.Models;
using GenshinBuilds.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Application.Services.Interfaces;

public interface ICharacterInformationService
{
    public Task<IEnumerable<MinimalCharacter>> GetAllMinimalCharacterInfo();
    public Task<DetailedCharacter> GetDetailedCharacterInfoById(Identity id);
}
