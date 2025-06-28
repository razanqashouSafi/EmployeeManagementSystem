using System.ComponentModel.DataAnnotations;

namespace MyApp.Core.DTOs.Request
{
    public class SignupAdmnDTO
    {
        public string Username { get; set; }

       
        public string Email { get; set; }

     
        public string PasswordHash { get; set; }
    }
}
