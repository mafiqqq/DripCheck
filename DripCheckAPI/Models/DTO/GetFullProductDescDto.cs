using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace DripCheckAPI.Models.DTO
{
    public class GetFullProductDescDto
    {
        public int ProductOwnerId { get; set; }
        public string OwnerFirstName { get; set; } = "";
        public string OwnerLastName { get; set; } = "";
        public string EmailAddress { get; set; } = "";
        public string PhoneNum { get; set; } = "";
        public string ProductSerialNumber { get; set; } = "";
        public string ProductModel { get; set; } = "";
        public string ProductBrand { get; set; } = "";
        public string ProductColor { get; set; } = "";
        public string ProductImageUrl { get; set; } = "";
        public decimal ProductPrice { get; set; }
        public string ExpirationDate { get; set; } = "";
        public string WarrantyStatus { get; set; } = "";
    }
}
