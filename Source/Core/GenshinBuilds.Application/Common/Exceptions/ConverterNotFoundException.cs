using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Application;

public class ConverterNotFoundException : Exception
{
    public ConverterNotFoundException(string? message) : base(message)
    {
    }
}
