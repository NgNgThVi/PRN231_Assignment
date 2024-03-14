namespace SE160956_KeyboardShop_Assignment.APIClient.Models
{
    public class BookingModel
    {
        public Guid CustomerId { get; set; }
        public string FullName { get; set; } = null!;
        public string? EmailAddress { get; set; }
        public string Address { get; set; } = null!;
        /// <summary>
        /// Phuong thuc van chuyen
        /// </summary>
        public string Freight { get; set; } = null!;
        public double TotalPrice { get; set; }
    }
}
