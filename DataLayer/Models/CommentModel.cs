using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class CommentModel
    {
        [Key]
        public int CommentId { get; set; }
        [Required]
        public string Description { get; set; } = default!;
		[Required]
        public int UserId { get; set; }
        [Required]
        public int MovieId { get; set; }


        public UserModel User { get; set; } = default!;
		public MovieModel Movie { get; set; } = default!;
	}
}
