namespace NguyenNgocThaiVi_SE160956_Assignment.BussinessObjects.Models.Common
{
    public class BaseAuditableEntity
    {
        public Guid Id { get; set; }

        public BaseAuditableEntity() => Id = Guid.NewGuid();
    }
}
