    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Application.Common.Converters.Interfaces;

public interface IConverter<TFrom, TTo>
{
    TTo Convert(TFrom value);
}
