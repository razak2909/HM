using Dapper;
using HotelManagement.Models;
using HotelManagement.Queries;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace HotelManagement.DAO
{
    public class BookingsDAO
    {
        private readonly IDbConnection _db;

        public BookingsDAO()
        {
            _db = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DapperDb"].ConnectionString);
        }

        public IEnumerable<object> GetBookings()
        {
            return _db.Query(BookingsQueries.GetBookings).ToList();
        }



        public Booking GetBookingById(int id)
        {
            return _db.Query<Booking>(BookingsQueries.GetBookingById, new { Booking_ID = id }).FirstOrDefault();
        }

        public void AddBooking(Booking booking)
        {
            _db.Execute(BookingsQueries.AddBooking, booking);
        }

        public Booking UpdateBooking(Booking booking)
        {
            _db.Execute(BookingsQueries.UpdateBooking, booking);
            return GetBookingById(booking.Booking_ID);
        }

        public Booking DeleteBooking(int id)
        {
            var booking = GetBookingById(id);
            if (booking != null)
            {
                _db.Execute(BookingsQueries.DeleteBooking, new { Booking_ID = id });
            }
            return booking;
        }
    }
}
