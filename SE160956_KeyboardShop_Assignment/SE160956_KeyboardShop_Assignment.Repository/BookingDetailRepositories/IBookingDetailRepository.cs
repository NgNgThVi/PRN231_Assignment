using SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess;

namespace SE160956_KeyboardShop_Assignment.Repository.BookingDetailRepositories
{
    public interface IBookingDetailRepository
    {
        void SaveBookingDetail(BookingDetail BookingDetail);
        BookingDetail GetBookingDetailByBookingIdAndFlowerBouquetId(string BookingId, string flowerBouquetId);
        List<BookingDetail> GetBookingDetails();
        List<BookingDetail> GetBookingDetailsByBookingId(string BookingId);
        void UpdateBookingDetail(BookingDetail BookingDetail);
        void DeleteBookingDetail(BookingDetail BookingDetail);

    }
}
