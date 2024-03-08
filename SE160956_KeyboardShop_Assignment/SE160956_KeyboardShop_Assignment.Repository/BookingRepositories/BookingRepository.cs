using SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess;
using SE160956_KeyboardShop_Assignment.DataAccessObject.BookingDataAccessObject;
using SE160956_KeyboardShop_Assignment.DataAccessObject.BookingDetailDataAccessObject;

namespace SE160956_KeyboardShop_Assignment.Repository.BookingRepositories
{
    public class BookingRepository : IBookingRepository
    {
        public Booking SaveBooking(Booking Booking) => BookingDAO.Instance.SaveBooking(Booking);
        public Booking GetBookingById(string id) => BookingDAO.Instance.FindBookingById(id);
        public List<Booking> GetBookings() => BookingDAO.Instance.GetBookings();
        public List<Booking> GetAllBookingsByCustomerId(string customerId) => BookingDAO.Instance.FindAllBookingsByCustomerId(customerId);
        public void UpdateBooking(Booking Booking) => BookingDAO.Instance.UpdateBooking(Booking);
        public void DeleteBooking(Booking Booking) => BookingDAO.Instance.DeleteBooking(Booking);
        public List<BookingDetail> GetBookingDetails(string BookingId) => BookingDetailDAO.Instance.FindAllBookingDetailsByProductId(BookingId);
    }
}
