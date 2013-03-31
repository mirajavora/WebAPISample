namespace WebApiBlog.Models
{
    public class AuthenticationResult
    {
        public bool IsAuthenticated { get; set; }
        public User User { get; set; }
    }
}