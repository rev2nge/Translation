using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Translation.Application.Interfaces;
using Translation.Domain.Models;
using Translation.Infrastructure.Service;

class Program
{
    static async Task Main(string[] args)
    {
        var services = new ServiceCollection();
        ConfigureServices(services);

        var provider = services.BuildServiceProvider();
        var translationService = provider.GetRequiredService<ITranslationService>();

        Console.Write("Введите текст для перевода: ");
        var inputText = Console.ReadLine();

        Console.Write("Введите исходный язык (например 'ru'): ");
        var fromLang = Console.ReadLine();

        Console.Write("Введите целевой язык (например 'en'): ");
        var toLang = Console.ReadLine();

        var request = new TranslationRequest
        {
            Texts = new List<string> { inputText },
            FromLanguage = fromLang,
            ToLanguage = toLang
        };

        var translations = await translationService.TranslateAsync(request);

        Console.Write("Переводы: ");
        translations.TranslatedTexts.ForEach(Console.WriteLine);
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("C:\\Users\\Lucky-Buy.md\\Desktop\\Project\\Translation\\Translation\\Translation.Infrastructure\\Configuration\\appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        services.AddSingleton<IConfiguration>(configuration);
        services.AddHttpClient<TranslationService>();
        services.AddSingleton<ITranslationService, TranslationService>();
    }
}