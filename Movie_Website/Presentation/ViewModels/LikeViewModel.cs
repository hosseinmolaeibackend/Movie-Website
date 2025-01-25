using System.ComponentModel.DataAnnotations;

namespace Movie_Website.Presentation.ViewModels
{
	public class LikeViewModel
	{
		[Required]
		public int MovieId { get; set; }
		[Required]
		public int UserId { get; set; }
	}
}
