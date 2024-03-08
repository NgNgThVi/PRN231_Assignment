using System.ComponentModel.DataAnnotations;

namespace SE160956_KeyboardShop_Assignment.Models
{
    public class CreateBookingDetail
    {
        [Required]
        public string ProductID { get; set; }
        [Required]
        public int UnitPrice { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
