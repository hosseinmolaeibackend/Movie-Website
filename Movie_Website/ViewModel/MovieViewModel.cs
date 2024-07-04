using System.ComponentModel.DataAnnotations;

namespace Movie_Website.ViewModel
{
	public class MovieViewModel
	{
		[Required]
		[MaxLength(255)]
		public string MovieTitle { get; set; } = default!;
		[Required]
		public string MovieDescription { get; set; } = default!;
		[Required]
		public string Author { get; set; } = default!;
		
		public string? Url { get; set; }

		
		public string? ImageName { get; set; }

		public string? VideoName { get; set; }

		public IFormFile? Image { get; set; }
		public IFormFile Video { get;set; }=default!;
	}
}
