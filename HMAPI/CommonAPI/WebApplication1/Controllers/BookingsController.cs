using HotelManagement.Models;
using HotelManagement.Repo;
using System.Web.Http;
using WebApplication1.Helpers;

namespace HotelManagement.Controllers
{
    [Log]
    public class BookingsController : ApiController
    {
        private readonly BookingsRepo _bookingsRepo;
                
        public BookingsController()
        {
            _bookingsRepo = new BookingsRepo();
        }

        // GET : api/Bookings
        //[Authorize (Roles = "Manager")]
        [Authorize]
        public IHttpActionResult Get()
        {
            var result = _bookingsRepo.GetBookings();
            return Json(result);
        }

        // GET : api/Bookings/ID
        public IHttpActionResult Get(int id)
        {
            var result = _bookingsRepo.GetBookingById(id);
            return Json(result);
        }

        // POST : api/Bookings
        public IHttpActionResult Post(Booking booking)
        {
            var result = _bookingsRepo.AddBooking(booking);
            return Json(result);
        }

        // PUT : api/Bookings/ID
        public IHttpActionResult Put(int id,Booking booking)
        {
            booking.Booking_ID = id;
            var result = _bookingsRepo.UpdateBooking(booking);
            return Json(result);
        }

        // DELETE : api/Bookings/ID
        public IHttpActionResult Delete(int id)
        {
            var result = _bookingsRepo.DeleteBooking(id);
            return Json(result);
        }
    }
}
