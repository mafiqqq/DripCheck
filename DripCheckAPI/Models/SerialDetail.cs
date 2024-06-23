using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DripCheckAPI.Models
{
    public class SerialDetail
    {
        [Key]
        public int SerialDetailId { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        public string SerialNumber { get; set; } = "";
        [Column(TypeName = "nvarchar(100)")]
        public string ProductModel  { get; set; } = "";
        [Column(TypeName = "nvarchar(20)")]
        public string ProductColor { get; set; } = "";
        
    }
}
