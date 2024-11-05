using Grpc.Core;
using Translation.Application.Interfaces;
using Translation.Domain.Models;
using TranslationServerApp;

namespace Translation.GrpcService.Services
{
    public class TranslationGrpcService : Translator.TranslatorBase
    {
        private readonly ITranslationService _translationService;

        public TranslationGrpcService(ITranslationService translationService)
        {
            _translationService = translationService;
        }

        public override async Task<InfoResponse> GetInfo(InfoRequest request, ServerCallContext context)
        {
            var serviceInfo = _translationService.GetServiceInfo();
            return new InfoResponse
            {
                ExternalServiceName = serviceInfo.ExternalServiceName,
                CacheType = serviceInfo.CacheType,
                CacheSize = (int)serviceInfo.CacheSize
            };
        }

        public override async Task<TranslateResponse> Translate(TranslateRequest request, ServerCallContext context)
        {
            var translationRequest = new TranslationRequest
            {
                Texts = request.Texts.ToList(),
                FromLanguage = request.FromLanguage,
                ToLanguage = request.ToLanguage
            };

            var translationResponse = await _translationService.TranslateAsync(translationRequest);
            return new TranslateResponse { TranslatedTexts = { translationResponse.TranslatedTexts } };
        }
    }
}