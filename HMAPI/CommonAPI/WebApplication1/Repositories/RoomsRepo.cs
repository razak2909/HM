using HotelManagement.DAO;
using HotelManagement.Models;

using System;
using WebApplication1.Models;

namespace HotelManagement.Repo
{
    public class RoomsRepository
    {
        private readonly RoomsDAO _roomsDAO;

        public RoomsRepository()
        {
            _roomsDAO = new RoomsDAO();
        }

        public ResultModel GetRooms()
        {
            var result = new ResultModel();

            try
            {
                result.Data = _roomsDAO.GetRooms();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "An error occurred while retrieving rooms.";
                result.TechDetails = ex.Message;
            }

            return result;
        }

        public ResultModel GetRoomType(int RoomTypeId)
        {
            var result = new ResultModel();

            try
            {
                result.Data = _roomsDAO.GetRoomTypeNumber(RoomTypeId);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "An error occurred while retrieving rooms.";
                result.TechDetails = ex.Message;
            }

            return result;
        }

        public ResultModel GetRoomById(int id)
        {
            var result = new ResultModel();

            try
            {
                var room = _roomsDAO.GetRoomById(id);
                if (room != null)
                {
                    result.Data = room;
                    result.Success = true;
                }
                else
                {
                    result.Success = false;
                    result.ErrorMessage = $"Room with Room ID {id} not found in our database.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "An error occurred while retrieving the room.";
                result.TechDetails = ex.Message;
            }

            return result;
        }

        public ResultModel AddRoom(RoomsModel room)
        {
            var result = new ResultModel();

            try
            {
                room.CreatedBy = "Admin";
                room.CreatedAt = DateTime.Now;
                room.Status = true;
                room.LatestService = DateTime.Now;
                room.roomStatus = "CheckOut";

                _roomsDAO.AddRoom(room);
                result.Data = room;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "An error occurred while adding the room.";
                result.TechDetails = ex.Message;
            }

            return result;
        }

        public ResultModel UpdateRoom(RoomsModel room)
        {
            var result = new ResultModel();

            try
            {
                var updatedRoom = _roomsDAO.UpdateRoom(room);
                if (updatedRoom != null)
                {
                    result.Data = updatedRoom;
                    result.Success = true;
                }
                else
                {
                    result.Success = false;
                    result.ErrorMessage = $"Room with Room ID {room.RoomId} not found in our database.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "An error occurred while updating the room.";
                result.TechDetails = ex.Message;
            }

            return result;
        }

        public ResultModel DeleteRoom(int id)
        {
            var result = new ResultModel();

            try
            {
                var room = _roomsDAO.DeleteRoom(id);
                if (room != null)
                {
                    result.Data = room;
                    result.Success = true;
                }
                else
                {
                    result.Success = false;
                    result.ErrorMessage = $"Room with Room ID {id} not found in our database.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "An error occurred while deleting the room.";
                result.TechDetails = ex.Message;
            }

            return result;
        }

        public ResultModel GetDashboardDataRepository()
        {
            try
            {
                var obj = new RoomsDAO();
                return obj.GetAllDashboardDataQuery();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
