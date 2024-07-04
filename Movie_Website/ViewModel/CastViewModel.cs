using System.ComponentModel.DataAnnotations;

namespace Movie_Website.ViewModel
{
    public class CastViewModel
    {
        [Required]
        public string Name { get; set; } = default!;
        [Required]
        public string Bio { get; set; } = default!;
        public int Age { get; set; }

        public IFormFile? Image { get; set; }
        public string? ImageName { get; set; }
    }
}
