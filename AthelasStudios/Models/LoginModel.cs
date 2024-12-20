using System.ComponentModel.DataAnnotations;

namespace AthelasStudios.Models
{
    public class LoginModel
    {
        private string? _returnurl;

        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string? Password { get; set; }
        public string ReturnUrl
        {
            get
            {
                if (_returnurl is null)
                    return "/";
                else
                    return _returnurl;
            }
            set
            {
                _returnurl = value;
            }

        }
    }
}