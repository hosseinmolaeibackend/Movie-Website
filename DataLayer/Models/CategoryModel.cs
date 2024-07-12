using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class CategoryModel
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string GenerName { get; set; } = default!;

		public ICollection<GenerModel> Generes { get; set; } = default!;
	}
}
