using GenshinBuilds.Application;
using GenshinBuilds.MauiClient.Data;

using GenshinBuilds.Parser;
using GenshinBuilds.RelationalDb;
using Microsoft.Extensions.Logging;
using System;

namespace GenshinBuilds.MauiClient
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

            builder.Services.LoadApplicationDependency();
            builder.Services.AddRepository();
            builder.Services.AddParsers();
        

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
		    builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<WeatherForecastService>();

            var provider = builder.Services.BuildServiceProvider();

            return builder.Build();
        }
    }
}