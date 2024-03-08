namespace SE160956_KeyboardShop_Assignment.BussinessObject.Common
{
    public class BaseAuditableEntity
    {
        public Guid Id { get; set; }

        public DateTime Created { get; set; }

        public string? CreateBy { get; set; }

        public DateTime? LastModified { get; set; }

        public string? LastModifiedBy { get; set; }

        public bool IsDeleted { get; set; }

        protected BaseAuditableEntity()
        {
            Id = Guid.NewGuid();
            Created = DateTime.Now;
            IsDeleted = false;
        }
    }
}
