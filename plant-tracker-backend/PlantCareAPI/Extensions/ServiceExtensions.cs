using PlantCareAPI.LoggerService;

namespace PlantCareAPI.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
        });
    }
    
    public static void ConfigureIISIntegration(this IServiceCollection services)
    {
        services.Configure<IISServerOptions>(options =>
        {
            //TODO: define IIS options later
        });
    }
    
    public static void ConfigureLoggerService(this IServiceCollection services)
    {
        services.AddSingleton<ILoggerManager, LoggerManager>();
    }
}