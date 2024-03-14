using SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE160956_KeyboardShop_Assignment.DataAccessObject.ProducsDataAccessObject
{
    public class ProductDTO
    {
        public int ProductQuantity { get; set; }
        [Required, StringLength(40)]
        public string ProductName { get; set; } = null!;
        [Required, StringLength(40)]
        public string Description { get; set; } = null!;
        [Required]
        [Range(1, Int32.MaxValue)]
        public int UnitPrice { get; set; }
        [Required]
        [Range(1, Int32.MaxValue)]
        public int UnitsInStock { get; set; }
        public int ProductStatus { get; set; }
        [ForeignKey("Category")]
        public Guid CategoryID { get; set; }
        [ForeignKey("Supplier")]
        public Guid SupplierID { get; set; }

        public virtual Category? Category { get; set; }
        public virtual Supplier? Supplier { get; set; }
        public virtual ICollection<BookingDetail>? BookingDetails { get; set; }
    }
}
