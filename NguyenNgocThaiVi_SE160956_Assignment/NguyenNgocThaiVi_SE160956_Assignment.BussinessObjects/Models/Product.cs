using NguyenNgocThaiVi_SE160956_Assignment.BussinessObjects.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace NguyenNgocThaiVi_SE160956_Assignment.BussinessObjects.Models
{
    public class Product : BaseAuditableEntity
    {
        [ForeignKey("Category")]
        public Guid CategoryId { get; set; } 
        public string ProductName { get; set; } = null!;
        public string ProductDescription { get; set; } = null!;
        public double ProductPrice { get; set; }
        public string ProductImage { get; set; }    
        /// <summary>
        /// Số lượng sản phẩm còn lại
        /// </summary>
        public int ProductRemaining { get; set; }
        public bool ProductStatus { get; set; }

        public IList<BookingDetail> BookingDetails { get; set; }
        public virtual Category Category { get; set; }
    }
}
