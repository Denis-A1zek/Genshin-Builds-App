using GenshinBuilds.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenshinBuilds.RelationalDb.EntitiesConfiguration;

internal class CharacterTypeConfiguration : IdentityTypeConfiguration<Character>
{
    protected override string TableName => "Characters";

    protected override void AddConfigure(EntityTypeBuilder<Character> builder)
    {
        
    }
}
