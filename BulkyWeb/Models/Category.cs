using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        [MaxLength(30)]
        public string Name { get; set; } = null!;
        [DisplayName("Display Order")]
        [Range(0, 100)]
        public int DisplayOrder { get; set; }
    }
}
