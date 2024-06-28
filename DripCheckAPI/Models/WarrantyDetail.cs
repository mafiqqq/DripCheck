using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DripCheckAPI.Models
{
    public class WarrantyDetail
    {
        [Key]
        public int WarrantyDetailId { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd:MM:yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ExpirationDate { get; set; }
        public string WarrantyStatus { get; set; } = "";
        public ProductOwner? ProductOwner { get; set; }

    }
}
