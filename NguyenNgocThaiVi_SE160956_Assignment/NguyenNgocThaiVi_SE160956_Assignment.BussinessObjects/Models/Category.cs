using NguyenNgocThaiVi_SE160956_Assignment.BussinessObjects.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace NguyenNgocThaiVi_SE160956_Assignment.BussinessObjects.Models
{
    public class Category : BaseAuditableEntity
    {
        [Required, StringLength(40)]
        public string CategoryName { get; set; }
        [Required, StringLength(255)]
        public string Description { get; set; }

        public IList<Product> Products { get; set; }    
    }
}
