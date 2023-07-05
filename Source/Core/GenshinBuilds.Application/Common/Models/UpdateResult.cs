using GenshinBuilds.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Application.Common.Models;

public record UpdateResult
{
    public Guid Id { get; private set; }
    public int Count { get; private set; } 
    public string Message { get; private set; }

    public static UpdateResult Create(int updated, string message) =>
        new UpdateResult() { Id = Guid.NewGuid(), Count = updated, Message = message };
}
