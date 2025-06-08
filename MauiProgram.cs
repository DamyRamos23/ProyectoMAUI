using Microsoft.Extensions.Logging;
using SQLitePCL;

namespace ProyectoMAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            Batteries_V2.Init();
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            //SQL Lite
            string dbPath = FileAccessHelper.GetPathFile("alumnos.db3");
            //	builder.Services.AddSingleton<AlumnosModels>(s => ActivatorUtilities.CreateInstance<AlumnosModels>(s, dbPath));



            return builder.Build();
        }
    }
}
