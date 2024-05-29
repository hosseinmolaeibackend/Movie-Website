using System.ComponentModel.DataAnnotations;

namespace Movie_Website.Models
{
    public class CommentModel
    {
        [Key]
        public int CommentId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int MovieId { get; set; }


        public UserModel User { get; set; }
        public MovieModel Movie { get; set; }
    }
}
