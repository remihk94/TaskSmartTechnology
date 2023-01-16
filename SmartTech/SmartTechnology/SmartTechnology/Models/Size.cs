using System.ComponentModel.DataAnnotations;

namespace SmartTechnology.Models
{
    public class Size
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int SizeValue { get; set; }
        public ICollection<ProductVariant>? ProductVariants { get; set; }
    }
}
