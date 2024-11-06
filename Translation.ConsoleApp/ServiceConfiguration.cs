using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Translation.Application.Interfaces;
using Translation.Infrastructure.Services;

namespace Translation.ConsoleApp
{
    public static class ServiceConfiguration
    {
        public static void ConfigureServices(ServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("C:\\Users\\Lucky-Buy.md\\Desktop\\Project\\Translation\\Translation\\Translation.Infrastructure\\Configuration\\appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            services.AddSingleton<IConfiguration>(configuration);
            services.AddHttpClient<TranslationService>();
            services.AddSingleton<ICacheService, MemoryCacheService>();
            services.AddTransient<ITranslationService, TranslationService>();
        }
    }
}
