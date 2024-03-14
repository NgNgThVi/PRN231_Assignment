using SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess;
using SE160956_KeyboardShop_Assignment.DataAccessObject.BookingDataAccessObject;
using SE160956_KeyboardShop_Assignment.DataAccessObject.BookingDetailDataAccessObject;

namespace SE160956_KeyboardShop_Assignment.Repository.BookingRepositories
{
    public class BookingRepository : IBookingRepository
    {
        private BookingDAO _dao;

        public BookingRepository()
        {
            _dao = new BookingDAO();
        }

        public Booking SaveBooking(Booking Booking) => BookingDAO.Instance.SaveBooking(Booking);
        public Booking GetBookingById(string id) => BookingDAO.Instance.FindBookingById(id);
        public List<Booking> GetBookings() => BookingDAO.Instance.GetBookings();
        public List<Booking> GetAllBookingsByCustomerId(string customerId) => BookingDAO.Instance.FindAllBookingsByCustomerId(customerId);
        public void UpdateBooking(Booking Booking) => BookingDAO.Instance.UpdateBooking(Booking);
        public void DeleteBooking(Booking Booking) => BookingDAO.Instance.DeleteBooking(Booking);
        public List<BookingDetail> GetBookingDetails(string BookingId) => BookingDetailDAO.Instance.FindAllBookingDetailsByProductId(BookingId);

        public async Task<string> CreateBook(BookingDTO request)
        {
            try
            {
                await _dao.CreateBooking(request);
                return "Create Successfully!";
            }catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
