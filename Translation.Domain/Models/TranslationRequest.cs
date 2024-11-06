using System.ComponentModel.DataAnnotations;

namespace Translation.Domain.Models
{
    public class TranslationRequest
    {
        [Required]
        public List<string> Texts { get; set; }

        [Required, MinLength(2), MaxLength(2)]
        public string FromLanguage { get; set; }

        [Required, MinLength(2), MaxLength(2)]
        public string ToLanguage { get; set; }
    }
}