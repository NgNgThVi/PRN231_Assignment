using NguyenNgocThaiVi_SE160956_Assignment.BussinessObjects.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace NguyenNgocThaiVi_SE160956_Assignment.BussinessObjects.Models
{
    public class Booking : BaseAuditableEntity
    {
        public DateTime DateBooking { get; set; }
        public double TotalPrice { get; set; }
        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
