using System.ComponentModel.DataAnnotations;

namespace Movie_Website.Models
{
    public class LikeModel
    {
        [Key]
        public int LikeId { get; set; }
        [Required]
        public int MovieId { get; set; }
        [Required]
        public int UserId { get; set; }


        public UserModel User { get; set; }
        public MovieModel Movie { get; set; }

    }
}
