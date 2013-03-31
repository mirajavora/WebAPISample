using System.ComponentModel.DataAnnotations;

namespace WebApiBlog.ViewModels
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}