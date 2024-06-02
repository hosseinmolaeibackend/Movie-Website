using System.ComponentModel.DataAnnotations;

namespace Movie_Website.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [MaxLength(150)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = default!;
        [Required]
        [MaxLength(250)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = default!;

        public bool RememberMe { get; set; }
    }
}
