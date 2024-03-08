using SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess;
using SE160956_KeyboardShop_Assignment.DataAccessObject.BookingDetailDataAccessObject;

namespace SE160956_KeyboardShop_Assignment.Repository.BookingDetailRepositories
{
    public class BookingDetailRepository : IBookingDetailRepository
    {
        public void SaveBookingDetail(BookingDetail BookingDetail) => BookingDetailDAO.Instance.SaveBookingDetail(BookingDetail);
        public BookingDetail GetBookingDetailByBookingIdAndFlowerBouquetId(string orderId, string flowerBouquetId) => BookingDetailDAO.Instance.FindBookingDetailByBookingIdAndFlowerBouquetId(orderId, flowerBouquetId);
        public List<BookingDetail> GetBookingDetails() => BookingDetailDAO.Instance.GetBookingDetails();
        public List<BookingDetail> GetBookingDetailsByBookingId(string orderId) => BookingDetailDAO.Instance.FindAllBookingDetailsByBookingId(orderId);
        public void UpdateBookingDetail(BookingDetail BookingDetail) => BookingDetailDAO.Instance.UpdateBookingDetail(BookingDetail);
        public void DeleteBookingDetail(BookingDetail BookingDetail) => BookingDetailDAO.Instance.DeleteBookingDetail(BookingDetail);

    }
}
