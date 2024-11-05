using Grpc.Net.Client;
using TranslationClienApp;

using var channel = GrpcChannel.ForAddress("https://localhost:7153");
var client = new Translator.TranslatorClient(channel);

var infoResponse = await client.GetInfoAsync(new InfoRequest());
Console.WriteLine($"Service: {infoResponse.ExternalServiceName}");
Console.WriteLine($"Cache Type: {infoResponse.CacheType}");
Console.WriteLine($"Cache Size: {infoResponse.CacheSize}");

var translateRequest = new TranslateRequest
{
    Texts = {
                "What decides the fate of mankind in this world? Some invisible being or law"
            },
    FromLanguage = "en",
    ToLanguage = "ru"
};

var translateResponse = await client.TranslateAsync(translateRequest);

Console.WriteLine("Перевод:");
foreach (var translatedText in translateResponse.TranslatedTexts)
{
    Console.WriteLine(translatedText);
}