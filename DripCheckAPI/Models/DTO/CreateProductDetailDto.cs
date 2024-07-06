namespace DripCheckAPI.Models.DTO
{
    public class CreateProductDetailDto
    {
        public string ProductModel { get; set; } = "";
        public string ProductBrand { get; set; } = "";
        public string ProductColor { get; set; } = "";
        public string ProductImageUrl1 { get; set; } = "";
        public string ProductImageUrl2 { get; set; } = "";
        public string ProductImageUrl3 { get; set; } = "";
        public decimal ProductPrice { get; set; }
        public string ProductHeight { get; set; } = "";
        public string ProductWidth { get; set; } = "";
        public string ProductWeight { get; set; } = "";
        public string ProductDisplaySize { get; set; } = "";
        public string ProductDisplayType { get; set; } = "";
        public string ProductResolution { get; set; } = "";
        public string ProductProcessor { get; set; } = "";
        public string ProductOS { get; set; } = "";
        public string ProductMemoryRAM { get; set; } = "";
        public string ProductMemoryROM { get; set; } = "";
        public string ProductRearCamera { get; set; } = "";
        public string ProductFrontCamera { get; set; } = "";
        public string ProductBattery { get; set; } = "";
    }
}
