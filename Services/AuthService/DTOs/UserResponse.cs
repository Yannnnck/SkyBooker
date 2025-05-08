namespace AuthService.DTOs
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string EMail { get; set; } = string.Empty;
    }
}
