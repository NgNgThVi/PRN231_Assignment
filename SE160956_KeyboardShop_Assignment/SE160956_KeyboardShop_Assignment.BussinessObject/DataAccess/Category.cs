using SE160956_KeyboardShop_Assignment.BussinessObject.Common;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess
{
    public class Category : BaseAuditableEntity
    {
        [Required, StringLength(40)]
        public string CategoryName { get; set; } = null!;
        [Required, StringLength(255)]
        public string? Description { get; set; }

        [JsonIgnore]
        public virtual ICollection<Product>? Products { get; set; }
    }
}
