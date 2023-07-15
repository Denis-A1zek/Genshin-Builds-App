using GenshinBuilds.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.RelationalDb.EntitiesConfiguration;

internal class CharacterBuildTypeConfiguration : IdentityTypeConfiguration<CharacterBuild>
{
    protected override void AddConfigure(EntityTypeBuilder<CharacterBuild> builder)
    {
        
    }
}
