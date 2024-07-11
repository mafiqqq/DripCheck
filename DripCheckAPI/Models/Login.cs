using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace DripCheckAPI.Models
{
    public class Login
    {
        [Key]
        public int LoginId { get; set; }
        public string Username { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public string Email { get; set; } = "";
        [ValidateNever]
        public ICollection<ProductOwner>? ProductOwners { get; set; }
    }
}
