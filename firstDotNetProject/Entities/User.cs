using System.ComponentModel.DataAnnotations;

namespace firstDotNetProject.Entities
{
    public class User
    {
        [Required]
        public int Id { set; get; }
        [Required]
        public string Name { set; get; }
        [Required]
        public int age { set; get; }
        [Required]
        public string email { set; get; }
        [Required]
        public string password { set; get; }
    }
}
