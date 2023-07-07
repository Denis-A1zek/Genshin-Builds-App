using AutoFixture;
using GenshinBuilds.RelationalDb;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.UnitTesting;

public class FixtureFactory
{
    private static DatabaseContext _context;
    public static DatabaseContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<DatabaseContext>()
        .UseInMemoryDatabase(databaseName: "Test")
        .Options;

        _context = new DatabaseContext(options);

        return _context;
    }

    public static Fixture Fixture => new Fixture();

}
