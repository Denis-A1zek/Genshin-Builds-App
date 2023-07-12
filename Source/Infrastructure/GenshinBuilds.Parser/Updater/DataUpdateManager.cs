using GenshinBuilds.Application;
using GenshinBuilds.Application.Common.Models;
using GenshinBuilds.Application.Interfaces;
using GenshinBuilds.Domain.Interfaces;

namespace GenshinBuilds.Parser.Updater;

public class DataUpdateManager : IDataUpdateManager
{
    private readonly IEnumerable<IUpdateChecker> _updateCheckers;
    private readonly IEnumerable<IUpdateHandler> _updateHandlers;

    public DataUpdateManager(IEnumerable<IUpdateChecker> updateCheckers, 
        IEnumerable<IUpdateHandler> updateHandlers)
    {
        _updateCheckers = updateCheckers;
        _updateHandlers = updateHandlers;
    }
    public async Task<IReadOnlyCollection<UpdateDetails>> CheckUpdates()
    {
        List<UpdateDetails> updates = new();

        foreach (var chekcer in _updateCheckers)
        {
            var updateDetails = await chekcer.HasUpdateAsync();
            updates.Add(updateDetails);
        }

        return updates;
    }

    public async Task<IReadOnlyCollection<UpdateResult>> Update(IUpdateble[] updateble = null)
    {
        List<UpdateResult> updates = new();

        if (updateble != null) { }

        foreach (var handler in _updateHandlers)
        {
            var result = await handler.UpdateAsync();
            updates.Add(result);
        }

        return updates;
    }
}
