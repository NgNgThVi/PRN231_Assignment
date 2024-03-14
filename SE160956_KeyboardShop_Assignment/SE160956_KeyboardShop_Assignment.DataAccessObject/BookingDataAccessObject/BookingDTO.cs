namespace SE160956_KeyboardShop_Assignment.DataAccessObject.BookingDataAccessObject
{
    public class BookingDTO
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
        public List<ProductForBooking> ListProductsAndQuantity { get; set; } = null!;
    }
    public class ProductForBooking
    {
        public Guid ProductId { get; set; }
        public int ProductQuantity { get; set; }
    }
}
