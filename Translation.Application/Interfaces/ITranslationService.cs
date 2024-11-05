using Translation.Domain.Models;

namespace Translation.Application.Interfaces
{
    public interface ITranslationService
    {
        Task<TranslationResponse> TranslateAsync(TranslationRequest request);
        ServiceInfo GetServiceInfo();
    }
}