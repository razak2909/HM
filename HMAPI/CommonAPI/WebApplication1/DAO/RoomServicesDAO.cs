using Dapper;
using HotelManagement.Models;
using HotelManagement.Queries;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace HotelManagement.DAO
{
    public class RoomServicesDAO
    {
        private readonly IDbConnection _db;

        public RoomServicesDAO()
        {
            _db = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DapperDb"].ConnectionString);
        }

        public IEnumerable<RoomService> GetRoomServices()
        {
            return _db.Query<RoomService>(RoomServicesQueries.GetRoomServices).ToList();
        }

        public RoomService GetRoomServiceById(int id)
        {
            return _db.Query<RoomService>(RoomServicesQueries.GetRoomServiceById, new { ServiceId = id }).FirstOrDefault();
        }

        public void AddRoomService(RoomService roomService)
        {
            _db.Execute(RoomServicesQueries.AddRoomService, roomService);
        }

        public RoomService UpdateRoomService(RoomService roomService)
        {
            _db.Execute(RoomServicesQueries.UpdateRoomService, roomService);
            return GetRoomServiceById(roomService.ServiceId);
        }

        public RoomService DeleteRoomService(int id)
        {
            var roomService = GetRoomServiceById(id);
            if (roomService != null)
            {
                _db.Execute(RoomServicesQueries.DeleteRoomService, new { ServiceId = id });
            }
            return roomService;
        }
    }
}
