using GenshinBuilds.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.RelationalDb.EntitiesConfiguration;

internal class CharacterBuildTypeConfiguration : IdentityTypeConfiguration<AssemblyItem>
{
    protected override string TableName => "CharacterBuilds";

    protected override void AddConfigure(EntityTypeBuilder<AssemblyItem> builder)
    {
        
    }
}
