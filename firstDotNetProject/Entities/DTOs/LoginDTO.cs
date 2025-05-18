using System.ComponentModel.DataAnnotations;

namespace firstDotNetProject.Entities.DTOs
{
    public class LoginDTO
    {
        [Required]
        public string username;
        [Required]
        public string password;

    }
}
