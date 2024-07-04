using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace DripCheckAPI.Models.DTO
{
    public class ProductDetailDto
    {
        public int ProductDetailId { get; set; }
        public string ProductModel { get; set; } = "";
        public string ProductBrand { get; set; } = "";
        public string ProductColor { get; set; } = "";
        public string ProductImageUrl { get; set; } = "";
        public decimal ProductPrice { get; set; }
        public ICollection<ProductOwner>? ProductOwners { get; set; }
    }
}
