using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SE160956_KeyboardShop_Assignment.BussinessObject.Common;

namespace SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess
{
    public class BookingDetail
    {
        [ForeignKey("Booking")]
        public Guid BookingId { get; set; }
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }

        public virtual Booking? Booking { get; set; }
        public virtual Product? Product { get; set; }
    }
}
