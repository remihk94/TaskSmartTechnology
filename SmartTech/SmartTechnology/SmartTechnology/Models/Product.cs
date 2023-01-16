using System.ComponentModel.DataAnnotations;

namespace SmartTechnology.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(300)]
        public string NameAR  { get; set; }
        [Required]
        [StringLength(300)]
        public string NameEN { get; set; }
        [Required]
        [StringLength(300)]
        public string NameFR { get; set; }
        [StringLength(500)]
        public string DescriptionAR { get; set; }
        [StringLength(500)]
        public string DescriptionEN { get; set; }
        [StringLength(500)]
        public string DescriptionFR { get; set; }
        public ICollection<ProductVariant>? ProductVariants { get; set; }


    }
}
