using Translation.Domain.Models;

namespace Translation.ConsoleApp
{
    public static class TranslationRequestHelper
    {
        public static TranslationRequest CreateTranslationRequest()
        {
            Console.Write("Введите текст для перевода: ");
            var inputText = Console.ReadLine();

            Console.Write("Введите исходный язык (например 'ru'): ");
            var fromLang = Console.ReadLine();

            Console.Write("Введите целевой язык (например 'en'): ");
            var toLang = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(inputText) || string.IsNullOrWhiteSpace(fromLang) || string.IsNullOrWhiteSpace(toLang))
            {
                Console.WriteLine("Все поля обязательны для заполнения.");
                return null;
            }

            return new TranslationRequest
            {
                Texts = new List<string> { inputText },
                FromLanguage = fromLang,
                ToLanguage = toLang
            };
        }
    }
}
