using HotelManagement.DAO;
using HotelManagement.Models;

using System;
using WebApplication1.Models;

namespace HotelManagement.Repo
{
    public class RoomServicesRepo
    {
        private readonly RoomServicesDAO _roomServicesDAO;

        public RoomServicesRepo()
        {
            _roomServicesDAO = new RoomServicesDAO();
        }

        public ResultModel GetRoomServices()
        {
            var result = new ResultModel();
            try
            {
                result.Data = _roomServicesDAO.GetRoomServices();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "An error occurred while retrieving room services.";
                result.TechDetails = ex.Message;
            }
            return result;
        }

        public ResultModel GetRoomServiceById(int id)
        {
            var result = new ResultModel();
            try
            {
                var roomService = _roomServicesDAO.GetRoomServiceById(id);
                if (roomService != null)
                {
                    result.Data = roomService;
                    result.Success = true;
                }
                else
                {
                    result.Success = false;
                    result.ErrorMessage = $"Room service with ID {id} not found.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "An error occurred while retrieving the room service.";
                result.TechDetails = ex.Message;
            }
            return result;
        }

        public ResultModel AddRoomService(RoomService roomService)
        {
            var result = new ResultModel();
            try
            {
                roomService.CreatedBy = "Admin";
                roomService.CreatedAt = DateTime.Now;
                roomService.Status = true;
                _roomServicesDAO.AddRoomService(roomService);
                result.Data = roomService;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "An error occurred while adding the room service.";
                result.TechDetails = ex.Message;
            }
            return result;
        }

        public ResultModel UpdateRoomService(RoomService roomService)
        {
            var result = new ResultModel();
            try
            {
                var updatedRoomService = _roomServicesDAO.UpdateRoomService(roomService);
                if (updatedRoomService != null)
                {
                    result.Data = updatedRoomService;
                    result.Success = true;
                }
                else
                {
                    result.Success = false;
                    result.ErrorMessage = $"Room service with ID {roomService.ServiceId} not found.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "An error occurred while updating the room service.";
                result.TechDetails = ex.Message;
            }
            return result;
        }

        public ResultModel DeleteRoomService(int id)
        {
            var result = new ResultModel();
            try
            {
                var roomService = _roomServicesDAO.DeleteRoomService(id);
                if (roomService != null)
                {
                    result.Data = roomService;
                    result.Success = true;
                }
                else
                {
                    result.Success = false;
                    result.ErrorMessage = $"Room service with ID {id} not found.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "An error occurred while deleting the room service.";
                result.TechDetails = ex.Message;
            }
            return result;
        }
    }
}
