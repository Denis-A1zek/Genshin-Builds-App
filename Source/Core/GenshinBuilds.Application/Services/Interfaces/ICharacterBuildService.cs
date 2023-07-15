using GenshinBuilds.Application.Common.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Application.Services.Interfaces;

public interface ICharacterBuildService
{
    Task InsertBuild(CharacterBuildDto characterBuild);
    Task ChangeBuildPriority(Guid characterBuildId, int newPriority);
    Task DeleteBuildPriority(Guid characterBuildId);
}
