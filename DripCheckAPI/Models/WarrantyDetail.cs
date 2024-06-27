using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DripCheckAPI.Models
{
    public class WarrantyDetail
    {
        [Key]
        public int WarrantyDetailId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string OwnerFirstName { get; set; } = "";
        [Column(TypeName = "nvarchar(100)")]
        public string OwnerLastName { get; set; } = "";
        [Column(TypeName = "nvarchar(200)")]
        public string EmailAddress { get; set; } = "";
        [Column(TypeName = "nvarchar(20)")]
        [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Invalid phone number.")]
        public string PhoneNum { get; set; } = "";

        [DisplayFormat(DataFormatString = "{0:dd:MM:yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ExpirationDate { get; set; }
        [Required]
        [ForeignKey("ProductDetail")]
        public string ProductSerialNumber { get; set; } = "";
        [Required]
        public ProductDetail? ProductDetail { get; set; }

    }
}
