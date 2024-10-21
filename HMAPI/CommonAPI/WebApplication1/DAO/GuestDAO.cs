using Dapper;
using HotelManagement.Models;
using HotelManagement.Queries;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace HotelManagement.DAO
{
    public class GuestsDAO
    {
        private readonly IDbConnection _db;

        public GuestsDAO()
        {
            _db = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DapperDb"].ConnectionString);
        }

        public IEnumerable<object> GetGuests()
        {
            return _db.Query(GuestsQueries.GetGuests).ToList();
        }

        public Guest GetGuestById(int id)
        {
            return _db.Query<Guest>(GuestsQueries.GetGuestById, new { GuestId = id }).FirstOrDefault();
        }

        public int AddGuest(Guest guest)
        {
            var query = GuestsQueries.AddGuest;

            return _db.QueryFirst(query, guest).GuestId;
        }

        public decimal gerRoomPrice(int RoomTypeId)
        {
            var query = "select Price from RoomType where RoomTypeId = @RoomTypeId";
            var val = _db.QueryFirst(query , new { @RoomTypeId =  RoomTypeId}).Price;
            return val;
        }

        public bool UpdateRoomStatus(int RoomId)
        {
            var query = "update Rooms set roomStatus = 'Booked' where RoomId = @RoomId ";
            var val = -_db.Execute(query, new { @RoomId = RoomId });
            return val > 0;
        }

        public Guest UpdateGuest(Guest guest)
        {
            _db.Execute(GuestsQueries.UpdateGuest, guest);
            return GetGuestById(guest.GuestId);
        }

        public Guest DeleteGuest(int id)
        {
            var guest = GetGuestById(id);
            if (guest != null)
            {
                _db.Execute(GuestsQueries.DeleteGuest, new { GuestId = id });
            }
            return guest;
        }
    }
}
    