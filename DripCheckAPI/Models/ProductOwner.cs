using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DripCheckAPI.Models
{
    public class ProductOwner
    {
        public int ProductOwnerId { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string OwnerFirstName { get; set; } = "";
        [Column(TypeName = "nvarchar(100)")]
        public string OwnerLastName { get; set; } = "";
        [Column(TypeName = "nvarchar(200)")]
        public string EmailAddress { get; set; } = "";
        [Column(TypeName = "nvarchar(20)")]
        [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Invalid phone number.")]
        public string PhoneNum { get; set; } = "";
        public string ProductSerialNumber { get; set; } = "";
        public int ProductDetailId { get; set; }
        public ProductDetail? ProductDetail { get; set; }
        public int WarrantyDetailId { get; set; }
        public WarrantyDetail? WarrantyDetail { get; set;}
    }
}
