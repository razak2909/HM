using Dapper;
using HotelManagement.Models;
using HotelManagement.Queries;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WebApplication1.Models;

namespace HotelManagement.DAO
{
    public class RoomsDAO
    {
        private readonly IDbConnection _db;

        public RoomsDAO()
        {
            _db = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DapperDb"].ConnectionString);
        }

        public object GetRooms()
        {
            return _db.Query(RoomsQueries.GetRooms).ToList();
        }

        public object GetRoomTypeNumber(int RoomTypeId)
        {
            return _db.Query(RoomsQueries.GetRoomTypeNumber, new { @RoomTypeId = RoomTypeId }).ToList();
        }


        public RoomsModel GetRoomById(int id)
        {
            return _db.Query<RoomsModel>(RoomsQueries.GetRoomById, new { RoomId = id }).FirstOrDefault();
        }

        public void AddRoom(RoomsModel room)
        {
            _db.Execute(RoomsQueries.AddRoom, room);
        }

        public RoomsModel UpdateRoom(RoomsModel room)
        {
            _db.Execute(RoomsQueries.UpdateRoom, room);
            return GetRoomById(room.RoomId);
        }

       
        public RoomsModel DeleteRoom(int id)
        {
            var room = GetRoomById(id);
            if (room != null)
            {
                _db.Execute(RoomsQueries.DeleteRoom, new { RoomId = id });
            }
            return room;
        }

        public ResultModel GetAllDashboardDataQuery()
        {
            using (var cnn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DapperDb"].ConnectionString))
            {
                var Booking = cnn.Query("SELECT * FROM [dbo].[Rooms] WHERE roomStatus IN ('Booked', 'CheckedIn');");

                

                return new ResultModel()
                {
                    Success = true,
                    Data = new
                    {

                        totalBookings = Booking.Count(),
                       
                        

                    },
                    ErrorMessage = string.Empty,
                    TechDetails = string.Empty
                };
            }
        }
    }
}
