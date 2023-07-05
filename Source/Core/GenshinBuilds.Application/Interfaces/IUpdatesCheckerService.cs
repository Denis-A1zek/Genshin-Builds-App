using GenshinBuilds.Application.Common.Models;
using GenshinBuilds.Domain.Interfaces;

namespace GenshinBuilds.Application;

public interface IUpdatesCheckerService
{
    Task<UpdateDetails> HasUpdateAsync();
    Task<UpdateResult> UpdateDataAsync(IEnumerable<string> updatableTypes = null, bool isDeep = false);
}
