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
        public int UnitPrice { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int Discount { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public string? CreateBy { get; set; }

        public DateTime? LastModified { get; set; }

        public string? LastModifiedBy { get; set; }

        public bool IsDeleted { get; set; } = false;

        public virtual Booking? Booking { get; set; }
        public virtual Product? Product { get; set; }
    }
}
