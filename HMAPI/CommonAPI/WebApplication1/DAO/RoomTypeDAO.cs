using Dapper;
using HotelManagement.Models;
using HotelManagement.Queries;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace HotelManagement.DAO
{
    public class RoomTypesDAO
    {
        private readonly IDbConnection _db;

        public RoomTypesDAO()
        {
            _db = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DapperDb"].ConnectionString);
        }

        public IEnumerable<RoomTypes> GetRoomTypes()
        {
            return _db.Query<RoomTypes>(RoomTypesQueries.GetRoomTypes).ToList();
        }

        public RoomTypes GetRoomTypeById(int id)
        {
            return _db.Query<RoomTypes>(RoomTypesQueries.GetRoomTypeById, new { RoomTypeId = id }).FirstOrDefault();
        }

        public void AddRoomType(RoomTypes roomType)
        {
            _db.Execute(RoomTypesQueries.AddRoomType, roomType);
        }

        public RoomTypes UpdateRoomType(RoomTypes roomType)
        {
            _db.Execute(RoomTypesQueries.UpdateRoomType, roomType);
            return GetRoomTypeById(roomType.RoomTypeId);
        }

        public RoomTypes DeleteRoomType(int id)
        {
            var roomType = GetRoomTypeById(id);
            if (roomType != null)
            {
                _db.Execute(RoomTypesQueries.DeleteRoomType, new { RoomTypeId = id });
            }
            return roomType;
        }
    }
}
