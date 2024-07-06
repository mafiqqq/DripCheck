using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DripCheckAPI.Models
{
    public class ProductDetail
    {
        [Key]
        [Required]
        public int ProductDetailId { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string ProductModel { get; set; } = "";
        [Column(TypeName = "nvarchar(20)")]
        public string ProductBrand { get; set; } = "";
        [Column(TypeName = "nvarchar(20)")]
        public string ProductColor { get; set; } = "";
        public string ProductImageUrl1 { get; set; } = "";
        public string ProductImageUrl2 { get; set; } = "";
        public string ProductImageUrl3 { get; set; } = "";
        [Column(TypeName = "decimal(18,2)")]
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
        public ICollection<ProductOwner>? ProductOwners { get; set; }
    }
}


