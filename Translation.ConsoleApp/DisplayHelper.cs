using Translation.Application.Interfaces;
using Translation.Domain.Models;

namespace Translation.ConsoleApp
{
    public static class DisplayHelper
    {
        public static void DisplayTranslations(TranslationResponse response)
        {
            Console.WriteLine("Переводы:");
            response.TranslatedTexts.ForEach(Console.WriteLine);
        }

        public static void DisplayServiceInfo(ITranslationService translationService)
        {
            var serviceInfo = translationService.GetServiceInfo();
            Console.WriteLine("\nИнформация о сервисе:");
            Console.WriteLine($"Внешний сервис: {serviceInfo.ExternalServiceName}");
            Console.WriteLine($"Тип кэша: {serviceInfo.CacheType}");
            Console.WriteLine($"Размер кэша: {serviceInfo.CacheSize}");
        }
    }
}
