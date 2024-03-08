using SE160956_KeyboardShop_Assignment.BussinessObject.Common;

namespace SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess
{
    public class Customer : BaseAuditableEntity
    {
        public string AccountPassword { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public string? EmailAddress { get; set; }

        public int? Role { get; set; }

        public virtual ICollection<Booking>? Bookings { get; set; }
    }
}
