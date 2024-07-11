using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class LikeModel
    {
        [Key]
        public int LikeId { get; set; }
        [Required]
        public int MovieId { get; set; }
        [Required]
        public int UserId { get; set; }


        public UserModel User { get; set; } = default!;
		public MovieModel Movie { get; set; } = default!;

	}
}
