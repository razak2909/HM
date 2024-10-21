using HotelManagement.DAO;
using HotelManagement.Models;

using System;
using WebApplication1.Models;

namespace HotelManagement.Repo
{
    public class RoomTypesRepo
    {
        private readonly RoomTypesDAO _roomTypesDAO;

        public RoomTypesRepo()
        {
            _roomTypesDAO = new RoomTypesDAO();
        }

        public ResultModel GetRoomTypes()
        {
            var result = new ResultModel();
            try
            {
                result.Data = _roomTypesDAO.GetRoomTypes();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "An error occurred while retrieving room types.";
                result.TechDetails = ex.Message;
            }
            return result;
        }

        public ResultModel GetRoomTypeById(int id)
        {
            var result = new ResultModel();
            try
            {
                var roomType = _roomTypesDAO.GetRoomTypeById(id);
                if (roomType != null)
                {
                    result.Data = roomType;
                    result.Success = true;
                }
                else
                {
                    result.Success = false;
                    result.ErrorMessage = $"RoomType with ID {id} not found.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "An error occurred while retrieving the room type.";
                result.TechDetails = ex.Message;
            }
            return result;
        }

        public ResultModel AddRoomType(RoomTypes roomType)
        {
            var result = new ResultModel();
            try
            {
                roomType.CreatedBy = "Admin";
                roomType.CreatedAt = DateTime.Now;
                roomType.Status = true;
                _roomTypesDAO.AddRoomType(roomType);
                result.Data = roomType;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "An error occurred while adding the room type.";
                result.TechDetails = ex.Message;
            }
            return result;
        }

        public ResultModel UpdateRoomType(RoomTypes roomType)
        {
            var result = new ResultModel();
            try
            {
                var updatedRoomType = _roomTypesDAO.UpdateRoomType(roomType);
                if (updatedRoomType != null)
                {
                    result.Data = updatedRoomType;
                    result.Success = true;
                }
                else
                {
                    result.Success = false;
                    result.ErrorMessage = $"RoomType with ID {roomType.RoomTypeId} not found.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "An error occurred while updating the room type.";
                result.TechDetails = ex.Message;
            }
            return result;
        }

        public ResultModel DeleteRoomType(int id)
        {
            var result = new ResultModel();
            try
            {
                var roomType = _roomTypesDAO.DeleteRoomType(id);
                if (roomType != null)
                {
                    result.Data = roomType;
                    result.Success = true;
                }
                else
                {
                    result.Success = false;
                    result.ErrorMessage = $"RoomType with ID {id} not found.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "An error occurred while deleting the room type.";
                result.TechDetails = ex.Message;
            }
            return result;
        }
    }
}
