using System.ComponentModel.DataAnnotations;

namespace Movie_Website.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [MaxLength(150)]
        public string FullName { get; set; } = default!;
        [Required]
        [MaxLength(150)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = default!;
        [Required]
        [MaxLength(250)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = default!;

        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }


        ICollection<CommentModel> comments { get; set; } = default!;
        ICollection<LikeModel> like { get; set; } = default!;
    }
}
