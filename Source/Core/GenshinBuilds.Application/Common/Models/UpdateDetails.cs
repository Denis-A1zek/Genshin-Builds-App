
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Application.Common.Models;

public class UpdateDetails
{
    public DateTime UpdateTime { get; private set; }
    public bool HasUpdates { get; private set; } = false;
    public int Difference { get; private set; }
    public Type Type { get; private set; }

    public static UpdateDetails NotUpdated<T>() 
        => new UpdateDetails() { Difference = 0, Type = typeof(T), HasUpdates = false };
    public static UpdateDetails Updated<T>(int dif) 
        => new UpdateDetails() { Difference = dif, Type = typeof(T), HasUpdates = true, UpdateTime = DateTime.Now };
}
