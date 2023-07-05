using GenshinBuilds.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Application.Common.Models;

public class UpdateDetails
{
    public UpdateDetails()
    {
        UpdateTime = DateTime.Now;
        AvailableUpdates = new List<string>();
    }
    public DateTime UpdateTime { get; set; }
    public List<string> AvailableUpdates;
}
