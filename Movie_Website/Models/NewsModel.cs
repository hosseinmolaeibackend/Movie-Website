using System.ComponentModel.DataAnnotations;

namespace Movie_Website.Models
{
	public class NewsModel
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string ImageNews { get; set; } = default!;
		[Required]
		[MaxLength(255)]
		public string Title { get; set; }=default!;
		[Required]
		public string Description { get; set; } = default!;
		[Required]
		public DateTime CreateTime { get; set; } = default!;
		[Required]
		public int UserId { get; set; } = default!;

		public UserModel userModel { get; set; } = default!;
	}
}
