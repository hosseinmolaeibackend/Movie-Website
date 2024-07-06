using System.ComponentModel.DataAnnotations;

namespace Movie_Website.ViewModel
{
    public class NewsViewModel
    {
        [Required]
        public string ImageName { get; set; } = default!;
        [Required]
        public IFormFile Image {  get; set; }=default!;
        [Required]
        [MaxLength(255)]
        public string Title { get; set; } = default!;
        [Required]
        public string Description { get; set; } = default!;
        [Required]
        public DateTime CreateTime { get; set; } = default!;
        [Required]
        public int UserId { get; set; } = default!;
    }
}
