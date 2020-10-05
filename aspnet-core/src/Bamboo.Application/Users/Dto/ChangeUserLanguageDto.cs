using System.ComponentModel.DataAnnotations;

namespace Bamboo.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}