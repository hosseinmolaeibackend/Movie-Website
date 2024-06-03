using System.ComponentModel.DataAnnotations;

namespace Movie_Website.ViewModel
{
    public class CommentHelper
    {
        [Required]
        public string Description { get; set; } = default!;
        [Required]
        public int UserId { get; set; }
        [Required]
        public int MovieId { get; set; }
        [Required]
        [MaxLength(255)]
        public string MovieTitle { get; set; } = default!;
        [Required]
        public string MovieDescription { get; set; } = default!;
        [Required]
        public string Author { get; set; } = default!;
    }
}
