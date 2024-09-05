using MassTransit;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace MauiApp1
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddScoped<MainPage>();
            builder.Services.AddScoped<MainPageViewModel>();
            builder.Services.AddSingleton<MessageService>();
            builder.Services.AddMediator(cfg =>
                cfg.AddConsumers(Assembly.GetExecutingAssembly())
            );

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            var app =  builder.Build();

            // This would normally not be created here but somewhere in the application logic. 
            // We're creating an instance here as an example.
            var service = app.Services.GetRequiredService<MessageService>();

            return app;

        }
    }
}
