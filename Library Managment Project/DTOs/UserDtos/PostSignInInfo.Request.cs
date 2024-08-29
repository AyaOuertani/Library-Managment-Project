using Library_Managment_Project.Enum;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Library_Managment_Project.DTOs.UserDtos
{
    public class PostSignInInfoRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public UserRole Role { get; set; }

    }
}
