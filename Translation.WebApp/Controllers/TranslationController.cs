using Microsoft.AspNetCore.Mvc;
using Translation.Application.Interfaces;
using Translation.Domain.Models;

namespace Translation.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslationController : ControllerBase
    {
        private readonly ITranslationService _translationService;

        public TranslationController(ITranslationService translationService)
        {
            _translationService = translationService;
        }

        [HttpGet("GetInfo")]
        public ActionResult<ServiceInfo> GetInfo()
        {
            var info = _translationService.GetServiceInfo();
            return Ok(info);
        }

        [HttpPost("Translate")]
        public async Task<ActionResult<TranslationResponse>> Translate([FromBody] TranslationRequest request)
        {
            var response = await _translationService.TranslateAsync(request);
            return Ok(response);
        }
    }
}
