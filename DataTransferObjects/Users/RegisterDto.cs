using System.ComponentModel.DataAnnotations;

namespace CSharpAngular.Api.DataTransferObjects.Users
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}
