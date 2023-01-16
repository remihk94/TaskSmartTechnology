namespace SmartTechnology.Dto
{
    public class ProductVariantDto
    {
        public int Quantity { get; set; }
        public ColorDto? ColorDto { get; set; }
        public SizeDto? SizeDto { get; set; }
    }
}
