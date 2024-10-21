using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using WebApplication1.Helpers;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Log]
    public class BookingListController : ApiController
    {
        [Route("api/BookingList/getBookedList")]
        public IHttpActionResult getBookingList()
        {
            var obj = new BookingListRepo();
            var result = obj.GetBookingListRepo();

            return Ok(result);
        }


        [Route("api/BookingList/getBookingById/{id}")]
        public IHttpActionResult getBookingById(int id)
        {
            var obj = new BookingListRepo();
            var result = obj.GetBookingByIdRepo(id);

            return Ok(result);
        }

        [HttpPost]
        [Route("api/BookingList/addBooking")]
        public IHttpActionResult addBooking([FromBody] BookingModelList booking) // Ensure you have a model for Booking
        {
            var obj = new BookingListRepo();
            var result = obj.AddBookingRepo(booking);

            return Ok(result);
        }

        [HttpGet]
        [Route("api/BookingList/updateBooking")]
        public IHttpActionResult updateBooking(int roomid, int bookingId)
        {
            var obj = new BookingListRepo();
            var result = obj.UpdateBookingRepo(roomid, bookingId);

            return Ok(result);
        }


        [HttpGet]
        [Route("api/BookingList/updateBookingCheckOut")] 
        public IHttpActionResult UpdateBooking(int roomid, int bookingId) 
        {
            var obj = new BookingListRepo();
            var result = obj.UpdateBookingRepoCheckOut(roomid, bookingId);

            return Ok(result);
        }


        [HttpDelete]
        [Route("api/BookingList/deleteBooking/{id}")]
        public IHttpActionResult deleteBooking(int id)
        {
            var obj = new BookingListRepo();
            var result = obj.DeleteBookingRepo(id);

            return Ok(result);
        }






        [Route("api/BookingList/getCheckInList")]
        public IHttpActionResult getCheckedInList()
        {
            var obj = new BookingListRepo();
            var result = obj.GetCheckInListRepo();

            return Ok(result);
        }

        // Get by ID
        [Route("api/BookingList/getCheckInById/{id}")]
        public IHttpActionResult getCheckInById(int id)
        {
            var obj = new BookingListRepo();
            var result = obj.GetCheckInByIdRepo(id);

            return Ok(result);
        }

        // POST
        [HttpPost]
        [Route("api/BookingList/addCheckIn")]
        public IHttpActionResult addCheckIn([FromBody] BookingModelList booking)
        {
            var obj = new BookingListRepo();
            var result = obj.AddCheckInRepo(booking);

            return Ok(result);
        }

        // PUT
        [HttpPut]
        [Route("api/BookingList/updateCheckIn")]
        public IHttpActionResult updateCheckIn([FromBody] BookingModelList booking)
        {
            var obj = new BookingListRepo();
            var result = obj.UpdateCheckInRepo(booking);

            return Ok(result);
        }

        // DELETE
        [HttpDelete]
        [Route("api/BookingList/deleteCheckIn/{id}")]
        public IHttpActionResult deleteCheckIn(int id)
        {
            var obj = new BookingListRepo();
            var result = obj.DeleteCheckInRepo(id);

            return Ok(result);
        }






        [Route("api/BookingList/getCheckedOutList")]
        public IHttpActionResult getCheckedOutList()
        {
            var obj = new BookingListRepo();
            var result = obj.GetCheckOutListRepo();

            return Ok(result);
        }

        [Route("api/BookingList/getCheckOutById/{id:int}")]
        public IHttpActionResult getCheckOutById(int id)
        {
            var obj = new BookingListRepo();
            var result = obj.GetCheckOutByIdRepo(id);

            return Ok(result);
        }

        [HttpPost]
        [Route("api/BookingList/addCheckOut")]
        public IHttpActionResult addCheckOut([FromBody] BookingModelList checkOut)
        {
            var obj = new BookingListRepo();
            var result = obj.AddCheckOutRepo(checkOut);

            return Ok(result);
        }


        [HttpPut]
        [Route("api/BookingList/updateCheckOut/{id:int}")]
        public IHttpActionResult updateCheckOut(int id, [FromBody] BookingModelList checkOut)
        {
            var obj = new BookingListRepo();
            var result = obj.UpdateCheckOutRepo(id, checkOut);

            return Ok(result);
        }


        [HttpDelete]
        [Route("api/BookingList/deleteCheckOut/{id:int}")]
        public IHttpActionResult deleteCheckOut(int id)
        {
            var obj = new BookingListRepo();
            var result = obj.DeleteCheckOutRepo(id);

            return Ok(result);
        }





    }

}
