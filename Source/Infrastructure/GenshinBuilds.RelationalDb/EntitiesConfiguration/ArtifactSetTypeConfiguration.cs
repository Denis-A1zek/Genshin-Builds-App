using GenshinBuilds.Domain;
using GenshinBuilds.Domain.Models;
using GenshinBuilds.Domain.Models.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GenshinBuilds.RelationalDb.EntitiesConfiguration;

internal class ArtifactSetTypeConfiguration : IdentityTypeConfiguration<ArtifactSet>
{
    protected override string TableName => "ArtifactSet";

    protected override void AddConfigure(EntityTypeBuilder<ArtifactSet> builder)
    {
        builder.Property(e => e.Name).IsRequired();

        builder.Property(e => e.Stats)
           .HasConversion(
               v => string.Join("|", v),
               v => v.Split("|", StringSplitOptions.RemoveEmptyEntries).ToList());


        builder.HasMany(e => e.Artifacts)
            .WithOne()
            .HasForeignKey("ArtifactSetId")
            .OnDelete(DeleteBehavior.Cascade);

    }
}
