namespace DripCheckAPI.Models.DTO
{
    public class CreateProductDetailDto
    {
        public string ProductModel { get; set; } = "";
        public string ProductBrand { get; set; } = "";
        public string ProductColor { get; set; } = "";
        public string ProductImageUrl { get; set; } = "";
        public decimal ProductPrice { get; set; }
    }
}
