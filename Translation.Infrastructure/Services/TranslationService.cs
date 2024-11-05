﻿using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;
using Translation.Application.Interfaces;
using Translation.Domain.Models;

namespace Translation.Infrastructure.Service
{
    public class TranslationService : ITranslationService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        private static readonly HashSet<string> _cacheKeys = new HashSet<string>();

        public TranslationService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["GoogleTranslateApiKey"];
        }

        public async Task<TranslationResponse> TranslateAsync(TranslationRequest request)
        {
            var translations = new List<string>();

            foreach (var text in request.Texts)
            {
                var cacheKey = $"translate:{text}_{request.FromLanguage}_{request.ToLanguage}";

                var translation = await TranslateTextAsync(text, request.FromLanguage, request.ToLanguage);

                _cacheKeys.Add(cacheKey);
                translations.Add(translation);
            }

            return new TranslationResponse { TranslatedTexts = translations };
        }

        private async Task<string> TranslateTextAsync(string text, string fromLang, string toLang)
        {
            var url = $"https://translation.googleapis.com/language/translate/v2?key={_apiKey}";

            var requestData = new
            {
                q = text,
                source = fromLang,
                target = toLang,
                format = "text"
            };

            var content = new StringContent(JsonSerializer.Serialize(requestData), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error {response.StatusCode}: {errorMessage}");
            }

            var jsonResponse = await response.Content.ReadAsStringAsync();
            using var jsonDoc = JsonDocument.Parse(jsonResponse);
            var translatedText = jsonDoc
                .RootElement
                .GetProperty("data")
                .GetProperty("translations")[0]
                .GetProperty("translatedText")
                .GetString();

            return translatedText ?? string.Empty;
        }

        public ServiceInfo GetServiceInfo()
        {
            return new ServiceInfo
            {
                ExternalServiceName = "Google Translate API",
                CacheType = "In-Memory",
                CacheSize = _cacheKeys.Count
            };
        }
    }
}