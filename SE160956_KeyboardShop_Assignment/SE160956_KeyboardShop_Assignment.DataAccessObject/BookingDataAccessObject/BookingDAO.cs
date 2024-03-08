using SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess;
using SE160956_KeyboardShop_Assignment.BussinessObject.DbContexts;

namespace SE160956_KeyboardShop_Assignment.DataAccessObject.BookingDataAccessObject
{
    public class BookingDAO
    {
        private static BookingDAO _instance = null;
        private readonly ApplicationDbContext _dbContext = null;

        public BookingDAO()
        {
            if (_dbContext == null)
            {
                _dbContext = new ApplicationDbContext();
            }
        }

        public static BookingDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BookingDAO();
                }
                return _instance;
            }
        }

        public List<Booking> GetBookings()
        {
            var listBookings = new List<Booking>();
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    listBookings = context.Booking.ToList();
                    listBookings.ForEach(o => o.Customer = context.Customers.Find(o.CustomerID));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listBookings;
        }

        public List<Booking> FindAllBookingsByCustomerId(string customerId)
        {
            var listBookings = new List<Booking>();
            try
            {
                listBookings = _dbContext.Booking.Where(o => o.CustomerID == Guid.Parse(customerId)).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listBookings;
        }

        public Booking FindBookingById(string BookingId)
        {
            var Booking = new Booking();
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    Booking = context.Booking.SingleOrDefault(o => o.Id == Guid.Parse(BookingId));
                    if (Booking != null)
                    {
                        Booking.Customer = context.Customers.Find(Booking.CustomerID);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Booking;
        }

        public Booking SaveBooking(Booking Booking)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.Booking.Add(Booking);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Booking;
        }

        public void UpdateBooking(Booking Booking)
        {
            try
            {
                _dbContext.Entry(Booking).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteBooking(Booking Booking)
        {
            try
            {
                var BookingToDelete = _dbContext
                    .Booking
                    .SingleOrDefault(o => o.Id == Booking.Id);
                _dbContext.Booking.Remove(BookingToDelete);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
