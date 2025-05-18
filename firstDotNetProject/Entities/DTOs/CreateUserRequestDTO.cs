using System.ComponentModel.DataAnnotations;

namespace firstDotNetProject.Entities.DTOs
{
    public class CreateUserRequestDTO
    {
        public string Name { set; get; }
        [Required]
        public int age { set; get; }
        [Required]
        public string email { set; get; }
        [Required]
        public string password { set; get; }
    }
}
