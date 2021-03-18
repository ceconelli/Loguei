using System.ComponentModel.DataAnnotations;

namespace Loguei.Dtos
{
    public class UserUpdateDto
    {
        [Required]
        public string Name { get; set; }
        [Required] /*Use data annotation to assure the user will input this info, and no return a 505 error*/
        public string Password { get; set; }
        public string Email { get; set; }
    }
    
}

