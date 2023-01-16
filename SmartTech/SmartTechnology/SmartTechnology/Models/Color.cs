using System.ComponentModel.DataAnnotations;

namespace SmartTechnology.Models
{
    public class Color
    {
        [Key]
        public int Id { get; set; }
        [Required]
        // Arabic Value
        public string ColorValueAr { get; set; }
        [Required]
        // English Value
        public string ColorValueEn { get; set; }
        [Required]
        // French Value
        public string ColorValueFr { get; set; }

        public ICollection<ProductVariant>? ProductVariants { get; set; }
    }
}
