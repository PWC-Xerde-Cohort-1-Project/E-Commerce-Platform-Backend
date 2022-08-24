using System.ComponentModel.DataAnnotations;

namespace eCommerce.Model
{
    public class UserRegisterRequest
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required, MaxLength(10)]
        public string Password { get; set; } = string.Empty;
        [Required, Compare("Password")]
       public string ConfirmPassword { get; set; } = string.Empty;  
    }
}
