using System.ComponentModel.DataAnnotations;

namespace SE160956_KeyboardShop_Assignment.Models
{
    public class LoginModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
