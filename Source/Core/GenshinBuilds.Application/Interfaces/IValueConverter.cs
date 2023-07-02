    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Application.Interfaces;

public interface IValueConverter
{
    public TTo Convert<TFrom, TTo>(TFrom value);
}
