using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

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
        public int ProductDetailId { get; set; } // Foreign key
        [ValidateNever]
        public ProductDetail? ProductDetail { get; set; } // Navigation Property
        public int WarrantyDetailId { get; set; } // Foreign key
        [ValidateNever]
        public WarrantyDetail? WarrantyDetail { get; set; } // Navigation Property
        public int LoginId { get; set; } // Foreign key 
        [ValidateNever]
        public Login? Login { get; set; } // Navigation Property
        public int ProductSerialNumberId { get; set; } // Foreign key
        public ProductSerialNumber? ProductSerialNumber { get; set; } // Navigation Property
    }
}
