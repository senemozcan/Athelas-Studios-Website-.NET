using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record ResetPasswordDto
    {
        public String? UserName { get; init; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="password is required.")]
        public String? Password { get; init; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Confirm password is required.")]
        [Compare("Password" , ErrorMessage ="Password and confirmpassword must be the same.")]
        public String? ConfirmPassword { get; init; }
    }
}