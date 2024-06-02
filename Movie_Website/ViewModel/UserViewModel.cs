using System.ComponentModel.DataAnnotations;

namespace Movie_Website.ViewModel
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "what the hell?")]
        [MaxLength(150)]
        public string FullName { get; set; } = default!;
        [Required(ErrorMessage = "what the hell?")]
        [MaxLength(150)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = default!;
        [Required(ErrorMessage = "what the hell?")]
        [MaxLength(250)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = default!;

        [Required(ErrorMessage ="what the hell?")]
        [MaxLength(250)]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password is not async")]
        public string ConfirmPassword { get; set; } = default!;

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; } = default!;
    }
}
