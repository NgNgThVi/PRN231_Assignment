using SE160956_KeyboardShop_Assignment.BussinessObject.Common;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess
{
    public class Supplier : BaseAuditableEntity
    {
        [Required, StringLength(40)]
        public string SupplierName { get; set; } = null!;
        [Required, StringLength(255)]
        public string SupplierAddress { get; set; } = null!;
        [Required, StringLength(12)]
        public string Telephone { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<Product>? Products { get; set; }
    }
}
