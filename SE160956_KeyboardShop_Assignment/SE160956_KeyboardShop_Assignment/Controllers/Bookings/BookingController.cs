using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess;
using SE160956_KeyboardShop_Assignment.Models;
using SE160956_KeyboardShop_Assignment.Repository.BookingDetailRepositories;
using SE160956_KeyboardShop_Assignment.Repository.BookingRepositories;
using SE160956_KeyboardShop_Assignment.Repository.ProductRepositories;

namespace SE160956_KeyboardShop_Assignment.API.Controllers.Bookings
{
    [Route("api/v1/Booking")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private IBookingRepository _BookingRepository;
        private IBookingDetailRepository _BookingDetailRepository;
        private IProductRepository _ProductRepository;
        public BookingController(IBookingRepository BookingRepository,
            IBookingDetailRepository BookingDetailRepository,
            IProductRepository ProductRepository)
        {
            _BookingRepository = BookingRepository;
            _BookingDetailRepository = BookingDetailRepository;
            _ProductRepository = ProductRepository;
        }

        [Authorize(Roles = "1")]
        [HttpGet]
        public ActionResult<IEnumerable<Booking>> GetBookings() => Ok(_BookingRepository.GetBookings());

        [Authorize(Roles = "4")]
        [HttpGet("customer/{id}")]
        public ActionResult<IEnumerable<Booking>> GetAllBookingsByCustomerId(string id)
        {
            var listBooking = _BookingRepository.GetAllBookingsByCustomerId(id);
            foreach (var o in listBooking)
            {
                var BookingDetails = _BookingDetailRepository.GetBookingDetailsByBookingId(o.Id.ToString());
                o.BookingDetail = BookingDetails;
            }
            return Ok(listBooking);
        }

        [Authorize(Roles = "4")]
        [HttpGet("customer/detail/{id}")]
        public ActionResult<Booking> GetBookingDetailById(string id)
        {
            var Booking = _BookingRepository.GetBookingById(id);
            if (Booking == null)
            {
                return NotFound();
            }
            var BookingDetails = _BookingDetailRepository.GetBookingDetailsByBookingId(id);
            Booking.BookingDetail = BookingDetails;
            return Ok(Booking);
        }


        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public ActionResult<Booking> GetBookingById(string id)
        {
            var Booking = _BookingRepository.GetBookingById(id);
            if (Booking == null)
            {
                return NotFound();
            }
            var BookingDetails = _BookingDetailRepository.GetBookingDetailsByBookingId(id);
            Booking.BookingDetail = BookingDetails;
            return Ok(Booking);
        }

        [Authorize(Roles = "1, 4")]
        [HttpPost]
        public ActionResult<Booking> PostBooking(CreateBooking postBooking)
        {
            foreach (var od in postBooking.BookingDetails)
            {
                var fb = _ProductRepository.GetProductById(od.ProductID.ToString());
                if (fb == null)
                {
                    return NotFound();
                }
                if (fb.ProductStatus != 1)
                {
                    return BadRequest();
                }
                if (fb.UnitsInStock < od.Quantity)
                {
                    return BadRequest();
                }
            }
            var Booking = new Booking
            {
                BookingDate = postBooking.BookingDate,
                ShippedDate = null,
                Total = postBooking.Total,
                BookingStatus = 0,
                Freight = postBooking.Freight,
                CustomerID = Guid.Parse(postBooking.CustomerID)
            };
            var savedBooking = _BookingRepository.SaveBooking(Booking);
            foreach (var od in postBooking.BookingDetails)
            {
                var fb = _ProductRepository.GetProductById(od.ProductID.ToString());
                fb.UnitsInStock -= od.Quantity;
                var BookingDetail = new BookingDetail
                {
                    ProductId = Guid.Parse(od.ProductID),
                    UnitPrice = od.UnitPrice,
                    Quantity = od.Quantity,
                    BookingId = savedBooking.Id,
                    Discount = 0
                };
                _ProductRepository.UpdateProduct(fb);
                _BookingDetailRepository.SaveBookingDetail(BookingDetail);
            }
            return Ok(savedBooking);
        }

        [Authorize(Roles = "1")]
        [HttpPut("shipped/{id}")]
        public IActionResult PutBookingShipped(string id)
        {
            var oTmp = _BookingRepository.GetBookingById(id);
            if (oTmp == null)
            {
                return NotFound();
            }
            if (oTmp.BookingStatus != 0)
            {
                return BadRequest();
            }
            oTmp.ShippedDate = DateTime.Now;
            oTmp.BookingStatus = 1;
            _BookingRepository.UpdateBooking(oTmp);
            return NoContent();
        }

        [Authorize(Roles = "1")]
        [HttpPut("cancel/{id}")]
        public IActionResult PutBookingCancel(string id)
        {
            var oTmp = _BookingRepository.GetBookingById(id);
            if (oTmp == null)
            {
                return NotFound();
            }
            if (oTmp.BookingStatus != 0)
            {
                return BadRequest();
            }
            oTmp.BookingStatus = 2;
            _BookingRepository.UpdateBooking(oTmp);
            var BookingDetails = _BookingDetailRepository.GetBookingDetailsByBookingId(id);
            foreach (var od in BookingDetails)
            {
                var fb = _ProductRepository.GetProductById(od.ProductId.ToString());
                fb.UnitsInStock += od.Quantity;
                _ProductRepository.UpdateProduct(fb);
            }
            return NoContent();
        }
    }
}
