using Domain.Entities;

namespace Domain.DTOs
{
    public class LoginDto
    {
        public LoginDto(AppUser user)
        {
            User = user;
        }

        public AppUser User { get; set; }
        public bool Code { get; set; } = false;
        public string Token { get; set; } = "";

    }
}
