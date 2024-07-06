using System.ComponentModel.DataAnnotations;

namespace DripCheckAPI.Models
{
    public class Login
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public string Email { get; set; } = "";

    }
}
