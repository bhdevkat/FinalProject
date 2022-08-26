using System.ComponentModel.DataAnnotations;

namespace BusBoarding.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}