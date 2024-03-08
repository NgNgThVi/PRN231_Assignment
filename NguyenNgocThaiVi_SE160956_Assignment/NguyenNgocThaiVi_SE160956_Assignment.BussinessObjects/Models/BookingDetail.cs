using NguyenNgocThaiVi_SE160956_Assignment.BussinessObjects.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace NguyenNgocThaiVi_SE160956_Assignment.BussinessObjects.Models
{
    public class BookingDetail : BaseAuditableEntity
    {
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        [ForeignKey("Booking")]
        public Guid BookingId { get;set; }
        public int QuantityOfProduct { get; set; }
        public double PriceOfProduct { get; set; }


        public virtual Booking Booking { get; set; }
        public virtual Product Product { get; set; }
    }
}
