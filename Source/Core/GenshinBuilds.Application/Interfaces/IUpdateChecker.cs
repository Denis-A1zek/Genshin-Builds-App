using GenshinBuilds.Application.Common.Models;
using GenshinBuilds.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Application;

public interface IUpdateChecker
{
    Task<UpdateDetails> HasUpdateAsync();
}
