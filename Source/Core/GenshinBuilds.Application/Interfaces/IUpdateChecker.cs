using GenshinBuilds.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Application;

public interface IUpdateChecker<T>
{
    Task<UpdateDetails> HasUpdateAsync();
}
