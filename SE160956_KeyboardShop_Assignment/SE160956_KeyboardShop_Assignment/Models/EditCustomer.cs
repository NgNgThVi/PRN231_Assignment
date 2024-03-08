using System.ComponentModel.DataAnnotations;

namespace SE160956_KeyboardShop_Assignment.Models
{
    public class EditCustomer
    {
        [Required]
        public string CustomerName { get; set; }
        public string? AccountPassword { get; set; }
    }
}
