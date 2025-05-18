using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace firstDotNetProject.Entities
{
    public class Todo
    {
        [Required]
        public int Id;
        [Required]
        public string Title;
        public string Description;
        public bool IsDone;
        public DateTime CreatedAt;
        public Todo() 
        {
            IsDone = false;
            CreatedAt = DateTime.Now;
        }
    }
}
