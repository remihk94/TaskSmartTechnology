namespace SmartTechnology.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string NameAR { get; set; }
        public string NameEN { get; set; }
        public string NameFR { get; set; }
        public string DescriptionAR { get; set; }
        public string DescriptionEN { get; set; }
        public string DescriptionFR { get; set; }
        public List<ProductVariantDto> ProductVariantDtos { get; set; }
    }
}
