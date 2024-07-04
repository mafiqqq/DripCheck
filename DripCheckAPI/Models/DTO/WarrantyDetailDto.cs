using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace DripCheckAPI.Models.DTO
{
    public class WarrantyDetailDto
    {
        public int WarrantyDetailId { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string WarrantyStatus { get; set; } = "";
    }
}
