namespace Domain.DTOs
{
    public class LoginDto
    {
        public LoginDto(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; set; }
        public bool Code { get; set; } = false;
        public string Token { get; set; } = "";

    }
}
