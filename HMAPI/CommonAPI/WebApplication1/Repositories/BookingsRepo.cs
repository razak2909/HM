using HotelManagement.DAO;
using HotelManagement.Models;

using System;
using WebApplication1.Models;

namespace HotelManagement.Repo
{
    public class BookingsRepo
    {
        private readonly BookingsDAO _bookingsDAO;

        public BookingsRepo()
        {
            _bookingsDAO = new BookingsDAO();
        }

        public ResultModel GetBookings()
        {
            var result = new ResultModel();
            try
            {
                result.Data = _bookingsDAO.GetBookings();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "An error occurred while retrieving bookings.";
                result.TechDetails = ex.Message;
            }
            return result;
        }

        public ResultModel GetBookingById(int id)
        {
            var result = new ResultModel();
            try
            {
                var booking = _bookingsDAO.GetBookingById(id);
                if (booking != null)
                {
                    result.Data = booking;
                    result.Success = true;
                }
                else
                {
                    result.Success = false;
                    result.ErrorMessage = $"Booking with ID {id} not found.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "An error occurred while retrieving the booking.";
                result.TechDetails = ex.Message;
            }
            return result;
        }

        public ResultModel AddBooking(Booking booking)
        {
            var result = new ResultModel();
            try
            {
                booking.CreatedBy = "Admin";
                booking.CreatedAt = DateTime.Now;
                booking.Status = true;

                _bookingsDAO.AddBooking(booking);
                result.Data = booking;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "An error occurred while adding the booking.";
                result.TechDetails = ex.Message;
            }
            return result;
        }

        public ResultModel UpdateBooking(Booking booking)
        {
            var result = new ResultModel();
            try
            {
                var updatedBooking = _bookingsDAO.UpdateBooking(booking);
                if (updatedBooking != null)
                {
                    result.Data = updatedBooking;
                    result.Success = true;
                }
                else
                {
                    result.Success = false;
                    result.ErrorMessage = $"Booking with ID {booking.Booking_ID} not found.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "An error occurred while updating the booking.";
                result.TechDetails = ex.Message;
            }
            return result;
        }

        public ResultModel DeleteBooking(int id)
        {
            var result = new ResultModel();
            try
            {
                var booking = _bookingsDAO.DeleteBooking(id);
                if (booking != null)
                {
                    result.Data = booking;
                    result.Success = true;
                }
                else
                {
                    result.Success = false;
                    result.ErrorMessage = $"Booking with ID {id} not found.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "An error occurred while deleting the booking.";
                result.TechDetails = ex.Message;
            }
            return result;
        }
    }
}
