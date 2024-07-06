namespace DripCheckAPI.Models.DTO
{
    public class LoginDto
    {
        public string Username { get; set; } = "";
        public string PasswordHash { get; set; } = "";
    }
}
