using SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess;
using SE160956_KeyboardShop_Assignment.BussinessObject.DbContexts;

namespace SE160956_KeyboardShop_Assignment.DataAccessObject.BookingDetailDataAccessObject
{
    public class BookingDetailDAO
    {
        private static BookingDetailDAO _instance = null;
        private readonly ApplicationDbContext _dbContext = null;

        public BookingDetailDAO()
        {
            if (_dbContext == null)
            {
                _dbContext = new ApplicationDbContext();
            }
        }

        public static BookingDetailDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BookingDetailDAO();
                }
                return _instance;
            }
        }

        public List<BookingDetail> GetBookingDetails()
        {
            var listBookingDetails = new List<BookingDetail>();
            try
            {
                listBookingDetails = _dbContext.BookingDetail.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listBookingDetails;
        }

        public List<BookingDetail> FindAllBookingDetailsByProductId(string flowerBouquetId)
        {
            var listBookingDetails = new List<BookingDetail>();
            try
            {
                listBookingDetails = _dbContext
                    .BookingDetail
                    .Where(o => o.ProductId == Guid.Parse(flowerBouquetId))
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listBookingDetails;
        }

        public List<BookingDetail> FindAllBookingDetailsByBookingId(string BookingId)
        {
            var listBookingDetails = new List<BookingDetail>();
            try
            {
                listBookingDetails = _dbContext
                    .BookingDetail
                    .Where(o => o.BookingId == Guid.Parse(BookingId))
                    .ToList();
                listBookingDetails.ForEach(o =>
                    o.Product = _dbContext.Products.SingleOrDefault(f => f.Id == o.ProductId)
                );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listBookingDetails;
        }

        public BookingDetail FindBookingDetailByBookingIdAndFlowerBouquetId(string BookingId, string flowerBouquetId)
        {
            var BookingDetail = new BookingDetail();
            try
            {
                BookingDetail = _dbContext
                    .BookingDetail
                    .SingleOrDefault(o => o.BookingId == Guid.Parse(BookingId) && o.ProductId == Guid.Parse(flowerBouquetId));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return BookingDetail;
        }

        public void SaveBookingDetail(BookingDetail BookingDetail)
        {
            try
            {
                _dbContext.BookingDetail.Add(BookingDetail);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateBookingDetail(BookingDetail BookingDetail)
        {
            try
            {
                _dbContext.Entry(BookingDetail).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteBookingDetail(BookingDetail BookingDetail)
        {
            try
            {
                var BookingDetailToDelete = _dbContext
                    .BookingDetail
                    .SingleOrDefault(o => o.BookingId == BookingDetail.BookingId && o.ProductId == BookingDetail.ProductId);
                _dbContext.BookingDetail.Remove(BookingDetailToDelete);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
