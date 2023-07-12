using GenshinBuilds.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.RelationalDb.EntitiesConfiguration;

internal class BuildTypeConfiguration : IdentityTypeConfiguration<Build>
{
    protected override string TableName => "Builds";

    protected override void AddConfigure(EntityTypeBuilder<Build> builder)
    {
        
    }
}
