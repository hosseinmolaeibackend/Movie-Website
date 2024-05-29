using System.ComponentModel.DataAnnotations;

namespace Movie_Website.Models
{
    public class CategoryModel
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string GenerName { get; set; }

        ICollection<GenerModel> Generes { get; set; }
    }
}
