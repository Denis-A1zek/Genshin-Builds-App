using GenshinBuilds.Application.Common.Models;
using GenshinBuilds.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Application.Interfaces;

public interface IDataUpdateManagerParser
{
    Task<IReadOnlyCollection<UpdateDetails>> CheckUpdates();
    Task<IReadOnlyCollection<UpdateResult>> Update(IUpdateble[] updateble = null);
}
