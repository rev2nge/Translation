using Microsoft.Extensions.DependencyInjection;
using Translation.Application.Interfaces;
using Translation.ConsoleApp;

class Program
{
    static async Task Main(string[] args)
    {
        var services = new ServiceCollection();
        ServiceConfiguration.ConfigureServices(services);

        var provider = services.BuildServiceProvider();
        var translationService = provider.GetRequiredService<ITranslationService>();

        var request = TranslationRequestHelper.CreateTranslationRequest();
        var translations = await translationService.TranslateAsync(request);

        DisplayHelper.DisplayTranslations(translations);

        DisplayHelper.DisplayServiceInfo(translationService);
    }
}