using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace NguyenNgocThaiVi_SE160956_Assignment.BussinessObjects.Models.Common
{
    public class ApplicationUser : BaseAuditableEntity
    {
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime? Birthday { get; set; }
        [ForeignKey("Role")]
        public Guid RoleId { get; set; }
        public virtual Role? Role { get; set; }
    }
}
