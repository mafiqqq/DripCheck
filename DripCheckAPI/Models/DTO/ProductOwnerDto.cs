using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DripCheckAPI.Models.DTO
{
    public class ProductOwnerDto
    {
        public int ProductOwnerId { get; set; }
        public string OwnerFirstName { get; set; } = "";
        public string OwnerLastName { get; set; } = "";
        public string EmailAddress { get; set; } = "";
        public string PhoneNum { get; set; } = "";
        public string ProductSerialNumber { get; set; } = "";
        public int ProductDetailId { get; set; }
        public int WarrantyDetailId { get; set; }
    }
}
