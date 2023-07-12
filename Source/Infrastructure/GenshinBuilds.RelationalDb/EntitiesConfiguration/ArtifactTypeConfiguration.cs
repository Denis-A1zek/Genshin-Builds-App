using GenshinBuilds.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.RelationalDb.EntitiesConfiguration;

internal class ArtifactTypeConfiguration : IdentityTypeConfiguration<Artifact>
{
    protected override string TableName => "Artifacts";

    protected override void AddConfigure(EntityTypeBuilder<Artifact> builder)
    {
        
    }
}
