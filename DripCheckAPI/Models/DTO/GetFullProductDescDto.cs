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
        //public string ProductSerialNumber { get; set; } = "";
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
        public string ProductRelDate { get; set; } = "";
        public string ExpirationDate { get; set; } = "";
        public string WarrantyStatus { get; set; } = "";
        public int WarrantyDetailId { get; set; }
        public int LoginId { get; set; }
    }
}
