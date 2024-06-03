using System.ComponentModel.DataAnnotations;

namespace Movie_Website.ViewModel
{
    public class CommentViewModel
    {
        [Required]
        public string Description { get; set; } = default!;
        [Required]
        public int UserId { get; set; }
        [Required]
        public int MovieId { get; set; }
    }
}
