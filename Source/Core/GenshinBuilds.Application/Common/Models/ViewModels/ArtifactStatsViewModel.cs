using GenshinBuilds.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Application.Common.Models.ViewModels;

public sealed record ArtifactStatsViewModel
{
    public Artifact Artifact { get; set; }
    public string Stats { get; set; }
}
