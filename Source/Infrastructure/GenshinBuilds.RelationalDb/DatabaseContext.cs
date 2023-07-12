using GenshinBuilds.Domain.Models;
using GenshinBuilds.RelationalDb.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;

namespace GenshinBuilds.RelationalDb;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) : base(options) { }

    //protected override void OnConfiguring(DbContextOptionsBuilder options)
    //        => options.UseSqlite();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);


        base.OnModelCreating(modelBuilder);
    }

}
