using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DripCheckAPI.Models
{
    public class ProductSerialNumber
    {
        public int ProductSerialNumberId { get; set; }
        public string SerialNumber { get; set; } = ""; // User provided
        public int ProductDetailId { get; set; } = 0; // Foreign key
        public bool isAvailable { get; set; } = true;
        public ProductDetail? ProductDetail { get; set; } // Navigation property
        [ValidateNever]
        public ProductOwner? ProductOwner { get; set; }
    }
}
