using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SE160956_KeyboardShop_Assignment.BussinessObject.Common;

namespace SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess
{
    public class Booking : BaseAuditableEntity
    {
        public DateTime BookingDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        [Required]
        public int Total { get; set; }
        [Required]
        public int BookingStatus { get; set; }
        [Required]
        public string? Freight { get; set; }
        [ForeignKey("Customer")]
        public Guid CustomerID { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual ICollection<BookingDetail>? BookingDetail { get; set; }
    }
}
