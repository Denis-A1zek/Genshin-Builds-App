using GenshinBuilds.Application;
using GenshinBuilds.Application.Common.Models;
using GenshinBuilds.Application.Interfaces;
using GenshinBuilds.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Updater;

public class DataUpdateManager : IDataUpdateManager
{
    private readonly IEnumerable<IUpdateHandler> _updateHandlers;

    public DataUpdateManager(IEnumerable<IUpdateHandler> updateHandlers)
        => _updateHandlers = updateHandlers;

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
