﻿using SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess;
using SE160956_KeyboardShop_Assignment.DataAccessObject.BookingDataAccessObject;

namespace SE160956_KeyboardShop_Assignment.Repository.BookingRepositories
{
    public interface IBookingRepository
    {
        Booking SaveBooking(Booking Booking);
        Booking GetBookingById(string id);
        List<Booking> GetBookings();
        List<Booking> GetAllBookingsByCustomerId(string customerId);
        void UpdateBooking(Booking Booking);
        void DeleteBooking(Booking Booking);
        List<BookingDetail> GetBookingDetails(string BookingId);

        Task<string> CreateBook(BookingDTO request);

    }
}
