using System.ComponentModel.DataAnnotations;

namespace Loguei.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
        [Key]
        public string Email { get; set; }
    }
    
}

