using GenshinBuilds.Application.Common.Models;


namespace GenshinBuilds.Application;

public interface IUpdatesCheckerService
{
    Task<IEnumerable<UpdateDetails>> HasUpdateAsync();
    Task<UpdateResult> UpdateDataAsync(IEnumerable<string> updatableTypes = null, bool isDeep = false);
}
