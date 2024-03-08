using System.ComponentModel.DataAnnotations;

namespace SE160956_KeyboardShop_Assignment.Models
{
    public class RegisterModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string AccountPassword { get; set; }
    }
}
