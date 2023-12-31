﻿using GenshinBuilds.Application.Common.Models;
using GenshinBuilds.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Application.Interfaces;

public interface IDataUpdateManager
{
    Task<IReadOnlyCollection<UpdateResult>> Update(IUpdateble[] updateble = null);
}
