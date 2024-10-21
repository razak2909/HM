using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.DAO;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class BookingListRepo
    {
        private readonly BookingListDAO _BookingListDAO;

        public BookingListRepo()
        {
            _BookingListDAO = new BookingListDAO();
        }
        public ResultModel GetBookingListRepo()
        {
            try
            {
                var val = new BookingListDAO();

                var result = val.getBookedApplication();

                if (result == null)
                {
                    return new ResultModel()
                    {
                        Success = false,
                        Data = null,
                        ErrorMessage = "no data Found",
                        TechDetails = "No data Found"
                    };
                }

                return new ResultModel() 
                {
                    Success = true,
                    Data = result,
                    ErrorMessage = string.Empty,
                    TechDetails = string.Empty
                };
            }
            catch (Exception ex)
            {
                return new ResultModel()
                {
                    Success = false,
                    Data = null,
                    ErrorMessage = "error getting data",
                    TechDetails = ex.Message + Environment.NewLine + ex.ToString() + Environment.NewLine + (ex.InnerException == null ? "" : ex.InnerException.ToString())
                };
            }
        }


        public ResultModel GetBookingByIdRepo(int id)
        {
            try
            {
                var val = new BookingListDAO();
                var result = val.getBookingById(id); // Implement this in DAO

                if (result == null)
                {
                    return new ResultModel()
                    {
                        Success = false,
                        Data = null,
                        ErrorMessage = "Booking not found",
                        TechDetails = "No booking found with the provided ID"
                    };
                }

                return new ResultModel()
                {
                    Success = true,
                    Data = result,
                    ErrorMessage = string.Empty,
                    TechDetails = string.Empty
                };
            }
            catch (Exception ex)
            {
                return new ResultModel()
                {
                    Success = false,
                    Data = null,
                    ErrorMessage = "Error getting booking",
                    TechDetails = ex.Message + Environment.NewLine + ex.ToString() + Environment.NewLine + (ex.InnerException == null ? "" : ex.InnerException.ToString())
                };
            }
        }


        public ResultModel AddBookingRepo(BookingModelList booking)
        {
            try
            {
                var val = new BookingListDAO();

                booking.BookingDate = DateTime.Now;
                booking.CreatedBy = "Admin";
                booking.CreatedAt = DateTime.Now;
                booking.Status = true;
                

                val.addBooking(booking); // Implement this in DAO

                return new ResultModel()
                {
                    Success = true,
                    Data = null,
                    ErrorMessage = string.Empty,
                    TechDetails = "Booking added successfully"
                };
            }
            catch (Exception ex)
            {
                return new ResultModel()
                {
                    Success = false,
                    Data = null,
                    ErrorMessage = "Error adding booking",
                    TechDetails = ex.Message + Environment.NewLine + ex.ToString() + Environment.NewLine + (ex.InnerException == null ? "" : ex.InnerException.ToString())
                };
            }
        }


        public ResultModel UpdateBookingRepo(int roomId, int bookingId)
        {
            try
            {
                var val = new BookingListDAO();
                var lines = val.updateBooking(roomId, bookingId); // Implement this in DAO

                return new ResultModel()
                {
                    Success = true,
                    Data = null,
                    ErrorMessage = string.Empty,
                    TechDetails = "Booking updated successfully"
                };
            }
            catch (Exception ex)
            {
                return new ResultModel()
                {
                    Success = false,
                    Data = null,
                    ErrorMessage = "Error updating booking",
                    TechDetails = ex.Message + Environment.NewLine + ex.ToString() + Environment.NewLine + (ex.InnerException == null ? "" : ex.InnerException.ToString())
                };
            }
        }

        public ResultModel UpdateBookingRepoCheckOut(int roomId, int bookingId)
        {
            try
            {
                var val = new BookingListDAO();
               
                var lines = val.updateBookingCheckout(roomId, bookingId); // Implement this in DAO

                return new ResultModel()
                {
                    Success = true,
                    Data = null,
                    ErrorMessage = string.Empty,
                    TechDetails = "Booking updated successfully"
                };
            }
            catch (Exception ex)
            {
                return new ResultModel()
                {
                    Success = false,
                    Data = null,
                    ErrorMessage = "Error updating booking",
                    TechDetails = ex.Message + Environment.NewLine + ex.ToString() + Environment.NewLine + (ex.InnerException == null ? "" : ex.InnerException.ToString())
                };
            }
        }


        public ResultModel DeleteBookingRepo(int id)
        {
            try
            {
                var val = new BookingListDAO();
                val.deleteBooking(id); // Implement this in DAO

                return new ResultModel()
                {
                    Success = true,
                    Data = null,
                    ErrorMessage = string.Empty,
                    TechDetails = "Booking deleted successfully"
                };
            }
            catch (Exception ex)
            {
                return new ResultModel()
                {
                    Success = false,
                    Data = null,
                    ErrorMessage = "Error deleting booking",
                    TechDetails = ex.Message + Environment.NewLine + ex.ToString() + Environment.NewLine + (ex.InnerException == null ? "" : ex.InnerException.ToString())
                };
            }
        }


        public ResultModel GetCheckInListRepo()
        {
            try
            {
                var val = new BookingListDAO();

                var result = val.GetCheckInApplication();

                if (result == null)
                {
                    return new ResultModel()
                    {
                        Success = false,
                        Data = null,
                        ErrorMessage = "no data Found",
                        TechDetails = "No data Found"
                    };
                }

                return new ResultModel()
                {
                    Success = true,
                    Data = result,
                    ErrorMessage = string.Empty,
                    TechDetails = string.Empty
                };
            }
            catch (Exception ex)
            {
                return new ResultModel()
                {
                    Success = false,
                    Data = null,
                    ErrorMessage = "error getting data",
                    TechDetails = ex.Message + Environment.NewLine + ex.ToString() + Environment.NewLine + (ex.InnerException == null ? "" : ex.InnerException.ToString())
                };
            }
        }

        public ResultModel GetCheckInByIdRepo(int id)
        {
            try
            {
                var val = new BookingListDAO();

                var result = val.GetCheckInById(id);

                if (result == null)
                {
                    return new ResultModel()
                    {
                        Success = false,
                        Data = null,
                        ErrorMessage = "No data found for the provided ID",
                        TechDetails = "No data found"
                    };
                }

                return new ResultModel()
                {
                    Success = true,
                    Data = result,
                    ErrorMessage = string.Empty,
                    TechDetails = string.Empty
                };
            }
            catch (Exception ex)
            {
                return new ResultModel()
                {
                    Success = false,
                    Data = null,
                    ErrorMessage = "Error getting data",
                    TechDetails = ex.Message + Environment.NewLine + ex.ToString() + Environment.NewLine + (ex.InnerException == null ? "" : ex.InnerException.ToString())
                };
            }
        }


        public ResultModel AddCheckInRepo(BookingModelList booking)
        {
            try
            {
                var val = new BookingListDAO();

                var result = val.AddCheckIn(booking);

                if (!result.Success)
                {
                    return new ResultModel()
                    {
                        Success = false,
                        Data = null,
                        ErrorMessage = "Failed to add check-in",
                        TechDetails = result.TechDetails
                    };
                }

                return new ResultModel()
                {
                    Success = true,
                    Data = result.Data,
                    ErrorMessage = string.Empty,
                    TechDetails = string.Empty
                };
            }
            catch (Exception ex)
            {
                return new ResultModel()
                {
                    Success = false,
                    Data = null,
                    ErrorMessage = "Error adding check-in",
                    TechDetails = ex.Message + Environment.NewLine + ex.ToString() + Environment.NewLine + (ex.InnerException == null ? "" : ex.InnerException.ToString())
                };
            }
        }


        public ResultModel UpdateCheckInRepo(BookingModelList booking)
        {
            try
            {
                var val = new BookingListDAO();

                var result = val.UpdateCheckIn(booking);

                if (!result.Success)
                {
                    return new ResultModel()
                    {
                        Success = false,
                        Data = null,
                        ErrorMessage = "Failed to update check-in",
                        TechDetails = result.TechDetails
                    };
                }

                return new ResultModel()
                {
                    Success = true,
                    Data = result.Data,
                    ErrorMessage = string.Empty,
                    TechDetails = string.Empty
                };
            }
            catch (Exception ex)
            {
                return new ResultModel()
                {
                    Success = false,
                    Data = null,
                    ErrorMessage = "Error updating check-in",
                    TechDetails = ex.Message + Environment.NewLine + ex.ToString() + Environment.NewLine + (ex.InnerException == null ? "" : ex.InnerException.ToString())
                };
            }
        }


        public ResultModel DeleteCheckInRepo(int id)
        {
            try
            {
                var val = new BookingListDAO();

                var result = val.DeleteCheckIn(id);

                if (!result.Success)
                {
                    return new ResultModel()
                    {
                        Success = false,
                        Data = null,
                        ErrorMessage = "Failed to delete check-in",
                        TechDetails = result.TechDetails
                    };
                }

                return new ResultModel()
                {
                    Success = true,
                    Data = null,
                    ErrorMessage = string.Empty,
                    TechDetails = string.Empty
                };
            }
            catch (Exception ex)
            {
                return new ResultModel()
                {
                    Success = false,
                    Data = null,
                    ErrorMessage = "Error deleting check-in",
                    TechDetails = ex.Message + Environment.NewLine + ex.ToString() + Environment.NewLine + (ex.InnerException == null ? "" : ex.InnerException.ToString())
                };
            }
        }


        public ResultModel GetCheckOutListRepo()
        {
            try
            {
                var val = new BookingListDAO();

                var result = val.GetCheckOutApplication();

                if (result == null)
                {
                    return new ResultModel()
                    {
                        Success = false,
                        Data = null,
                        ErrorMessage = "no data Found",
                        TechDetails = "No data Found"
                    };
                }

                return new ResultModel()
                {
                    Success = true,
                    Data = result,
                    ErrorMessage = string.Empty,
                    TechDetails = string.Empty
                };
            }
            catch (Exception ex)
            {
                return new ResultModel()
                {
                    Success = false,
                    Data = null,
                    ErrorMessage = "error getting data",
                    TechDetails = ex.Message + Environment.NewLine + ex.ToString() + Environment.NewLine + (ex.InnerException == null ? "" : ex.InnerException.ToString())
                };
            }
        }


        public ResultModel GetCheckOutByIdRepo(int id)
        {
            try
            {
                var val = new BookingListDAO();
                var result = val.GetCheckOutById(id);

                if (result == null)
                {
                    return new ResultModel()
                    {
                        Success = false,
                        Data = null,
                        ErrorMessage = "No data found for the given ID",
                        TechDetails = "No data found"
                    };
                }

                return new ResultModel()
                {
                    Success = true,
                    Data = result,
                    ErrorMessage = string.Empty,
                    TechDetails = string.Empty
                };
            }
            catch (Exception ex)
            {
                return new ResultModel()
                {
                    Success = false,
                    Data = null,
                    ErrorMessage = "Error getting data",
                    TechDetails = ex.Message + Environment.NewLine + ex.ToString() + Environment.NewLine + (ex.InnerException == null ? "" : ex.InnerException.ToString())
                };
            }
        }


        public ResultModel AddCheckOutRepo(BookingModelList checkOut)
        {
            try
            {
                var val = new BookingListDAO();
                var result = val.AddCheckOut(checkOut);

                if (!result) // Assuming AddCheckOut returns a boolean indicating success
                {
                    return new ResultModel()
                    {
                        Success = false,
                        Data = null,
                        ErrorMessage = "Failed to add check-out",
                        TechDetails = "Unable to add check-out record"
                    };
                }

                return new ResultModel()
                {
                    Success = true,
                    Data = null,
                    ErrorMessage = string.Empty,
                    TechDetails = "Check-out added successfully"
                };
            }
            catch (Exception ex)
            {
                return new ResultModel()
                {
                    Success = false,
                    Data = null,
                    ErrorMessage = "Error adding check-out",
                    TechDetails = ex.Message + Environment.NewLine + ex.ToString() + Environment.NewLine + (ex.InnerException == null ? "" : ex.InnerException.ToString())
                };
            }
        }


        public ResultModel UpdateCheckOutRepo(int id, BookingModelList checkOut)
        {
            try
            {
                var val = new BookingListDAO();
                var result = val.UpdateCheckOut(id, checkOut);

                if (!result) // Assuming UpdateCheckOut returns a boolean indicating success
                {
                    return new ResultModel()
                    {
                        Success = false,
                        Data = null,
                        ErrorMessage = "Failed to update check-out",
                        TechDetails = "Unable to update check-out record"
                    };
                }

                return new ResultModel()
                {
                    Success = true,
                    Data = null,
                    ErrorMessage = string.Empty,
                    TechDetails = "Check-out updated successfully"
                };
            }
            catch (Exception ex)
            {
                return new ResultModel()
                {
                    Success = false,
                    Data = null,
                    ErrorMessage = "Error updating check-out",
                    TechDetails = ex.Message + Environment.NewLine + ex.ToString() + Environment.NewLine + (ex.InnerException == null ? "" : ex.InnerException.ToString())
                };
            }
        }


        public ResultModel DeleteCheckOutRepo(int id)
        {
            try
            {
                var val = new BookingListDAO();
                var result = val.DeleteCheckOut(id);

                if (!result) // Assuming DeleteCheckOut returns a boolean indicating success
                {
                    return new ResultModel()
                    {
                        Success = false,
                        Data = null,
                        ErrorMessage = "Failed to delete check-out",
                        TechDetails = "Unable to delete check-out record"
                    };
                }

                return new ResultModel()
                {
                    Success = true,
                    Data = null,
                    ErrorMessage = string.Empty,
                    TechDetails = "Check-out deleted successfully"
                };
            }
            catch (Exception ex)
            {
                return new ResultModel()
                {
                    Success = false,
                    Data = null,
                    ErrorMessage = "Error deleting check-out",
                    TechDetails = ex.Message + Environment.NewLine + ex.ToString() + Environment.NewLine + (ex.InnerException == null ? "" : ex.InnerException.ToString())
                };
            }
        }

    }

}
