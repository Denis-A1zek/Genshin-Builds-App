using Microsoft.EntityFrameworkCore;

namespace GenshinBuilds.RelationalDb;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) : base(options) { }
}
