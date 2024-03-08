using System.ComponentModel.DataAnnotations;

namespace SE160956_KeyboardShop_Assignment.Models
{
    public class CreateProduct
    {
        [Required, StringLength(40)]
        public string ProductName { get; set; }
        [Required, StringLength(40)]
        public string Description { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int UnitPrice { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int UnitsInStock { get; set; }
        [Required]
        public int ProductStatus { get; set; }
        [Required]
        public string CategoryID { get; set; }
        [Required]
        public string SupplierID { get; set; }
    }
}
