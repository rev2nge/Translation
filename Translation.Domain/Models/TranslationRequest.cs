namespace Translation.Domain.Models
{
    public class TranslationRequest
    {
        public List<string> Texts { get; set; }
        public string FromLanguage { get; set; }
        public string ToLanguage { get; set; }
    }
}