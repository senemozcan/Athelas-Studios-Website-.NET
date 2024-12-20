using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "User name is required")]
        public String? UserName { get; init; }

        [Required(ErrorMessage = "Email is required")]
        public String? Email { get; init; }

        [Required(ErrorMessage = "Password is required")]
        public String? Password { get; init; }
    }
}