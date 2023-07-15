using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Domain.Models
{
    public record ArtifactStats : Identity
    {
        public Guid ArtifactId { get; set; }
        public Artifact Artifact { get; set; }
        public string Stats { get; set; }
    }
}
