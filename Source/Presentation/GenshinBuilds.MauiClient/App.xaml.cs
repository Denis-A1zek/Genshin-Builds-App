using GenshinBuilds.RelationalDb;
using Microsoft.EntityFrameworkCore;

namespace GenshinBuilds.MauiClient
{
    public partial class App : IApplication
    {
        private readonly IServiceProvider _serviceProvider;
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _serviceProvider = serviceProvider;

            AddTestData().Wait();

            MainPage = new MainPage();
        }

        public async Task AddTestData()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                await using var ctx = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                await ctx.Database.MigrateAsync();

                // Use ctx to add test/seed data etc

                await ctx.SaveChangesAsync();
            }
        }
    }
}