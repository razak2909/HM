using HotelManagement.DAO;
using HotelManagement.Models;
using System;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace HotelManagement.Repo
{
    public class GuestsRepo
    {
        private readonly GuestsDAO _guestsDAO;
        public readonly BookingListRepo _BookingListDAO;

        public GuestsRepo()
        {
            _guestsDAO = new GuestsDAO();
            _BookingListDAO = new BookingListRepo();
        }

        public ResultModel GetGuests()
        {
            var result = new ResultModel();
            try
            {
                result.Data = _guestsDAO.GetGuests();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "An error occurred while retrieving guests.";
                result.TechDetails = ex.Message;
            }
            return result;
        }

        public ResultModel GetGuestById(int id)
        {
            var result = new ResultModel();
            try
            {
                var guest = _guestsDAO.GetGuestById(id);
                if (guest != null)
                {
                    result.Data = guest;
                    result.Success = true;
                }
                else
                {
                    result.Success = false;
                    result.ErrorMessage = $"Guest with ID {id} not found.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "An error occurred while retrieving the guest.";
                result.TechDetails = ex.Message;
            }
            return result;
        }

        public ResultModel AddGuest(Guest guest)
        {
            var result = new ResultModel();
            try
            {
                guest.CreatedBy = "Admin";
                guest.CreatedAt = DateTime.Now;
                guest.Status = true;


                guest.GuestId=_guestsDAO.AddGuest(guest);

                var roomPrice = _guestsDAO.gerRoomPrice(guest.RoomType);


                var BookingListData = new BookingModelList();

                
                BookingListData.GuestId = guest.GuestId;
                BookingListData.RoomId = guest.RoomId;
                BookingListData.TotalDays = guest.TotalDays;
                BookingListData.NumberOfGuests = guest.NumberOfGuests;
                



                BookingListData.TotalPrice = guest.TotalDays * roomPrice;

                _BookingListDAO.AddBookingRepo(BookingListData);

                _guestsDAO.UpdateRoomStatus(guest.RoomId);

                result.Data = guest;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "An error occurred while adding the guest.";
                result.TechDetails = ex.Message;
            }
            return result;
        }

        public ResultModel UpdateGuest(Guest guest)
        {
            var result = new ResultModel();
            try
            {
                var updatedGuest = _guestsDAO.UpdateGuest(guest);
                if (updatedGuest != null)
                {
                    result.Data = updatedGuest;
                    result.Success = true;
                }
                else
                {
                    result.Success = false;
                    result.ErrorMessage = $"Guest with ID {guest.GuestId} not found.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "An error occurred while updating the guest.";
                result.TechDetails = ex.Message;
            }
            return result;
        }

        public ResultModel DeleteGuest(int id)
        {
            var result = new ResultModel();
            try
            {
                var guest = _guestsDAO.DeleteGuest(id);
                if (guest != null)
                {
                    result.Data = guest;
                    result.Success = true;
                }
                else
                {
                    result.Success = false;
                    result.ErrorMessage = $"Guest with ID {id} not found.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "An error occurred while deleting the guest.";
                result.TechDetails = ex.Message;
            }
            return result;
        }
    }
}
