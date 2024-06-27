﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DripCheckAPI.Models
{
    public class ProductDetail
    {
        [Key]
        [MaxLength(20)]
        public string SerialNumber { get; set; } = "";
        [Column(TypeName = "nvarchar(100)")]
        public string ProductModel { get; set; } = "";
        [Column(TypeName = "nvarchar(20)")]
        public string ProductBrand { get; set; } = "";
        [Column(TypeName = "nvarchar(20)")]
        public string ProductColor { get; set; } = "";
        public string ProductImageUrl { get; set; } = "";
        [Column(TypeName = "decimal(18,2)")]
        public decimal ProductPrice { get; set; }
    }
}
