using GenshinBuilds.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.RelationalDb.EntitiesConfiguration;

internal class ArtifactSetTypeConfiguration : IdentityTypeConfiguration<ArtifactSet>
{
    protected override string TableName => "ArtifactSet";

    protected override void AddConfigure(EntityTypeBuilder<ArtifactSet> builder)
    {
        
    }
}
