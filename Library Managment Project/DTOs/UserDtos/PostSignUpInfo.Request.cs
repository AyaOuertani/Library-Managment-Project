using Library_Managment_Project.Enum;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Library_Managment_Project.DTOs.UserDtos
{
    public class PostSignUpInfoRequest
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public UserRole Role { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
        public string Password { get; set; }
    }
}
