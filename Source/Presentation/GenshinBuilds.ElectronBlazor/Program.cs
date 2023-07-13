using ElectronNET.API;
using ElectronNET.API.Entities;
using GenshinBuilds.Application;
using GenshinBuilds.Parser;
using GenshinBuilds.RelationalDb;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using GenshinBuilds.GenshinDbApi;
using GenshinBuilds.Updater;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.LoadApplicationDependency();
builder.Services.AddRepository(builder.Configuration);
builder.Services.AddApiCalls();
builder.Services.AddUpdater();

builder.Services.AddElectron();

builder.WebHost.UseElectron(args);

if (HybridSupport.IsElectronActive)
{
    // Open the Electron-Window here
    Task.Run(async () => {
        var window = await Electron.WindowManager.CreateWindowAsync();
        window.Center();
        window.RemoveMenu();
        window.SetSize(1100, 700);
        window.SetMinimumSize(1100, 700);
        window.OnClosed += () =>
        {
            Electron.App.Quit();
        };
    });
}
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<DatabaseContext>();
        context.Database.EnsureCreated();
        context.Database.Migrate();
    }
    catch (Exception ex) { }
}


app.Run();
