using System.ComponentModel.DataAnnotations;

namespace SE160956_KeyboardShop_Assignment.Models
{
    public class CreateBooking
    {
        [Required]
        public DateTime BookingDate { get; set; }
        [Required]
        public int Total { get; set; }
        [Required]
        public string Freight { get; set; }
        [Required]
        public string CustomerID { get; set; }
        [Required]
        public List<CreateBookingDetail> BookingDetails { get; set; }
    }
}
