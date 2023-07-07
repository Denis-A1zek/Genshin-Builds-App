using GenshinBuilds.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.RelationalDb.EntitiesConfiguration;

internal class WeaponTypeConfiguration : IdentityTypeConfiguration<Weapon>
{
    protected override string TableName => "Weapons";

    protected override void AddConfigure(EntityTypeBuilder<Weapon> builder)
    {
        builder.OwnsOne(w => w.Modifier, modifier =>
        {
            modifier.Property(m => m.Title);
            modifier.Property(m => m.Description);
        });
    }
}
