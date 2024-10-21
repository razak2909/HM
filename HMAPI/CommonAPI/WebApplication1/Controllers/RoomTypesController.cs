using HotelManagement.Models;
using HotelManagement.Repo;
using System.Web.Http;

namespace HotelManagement.Controllers
{
    public class RoomTypesController : ApiController
    {
        private readonly RoomTypesRepo _roomTypesRepo;

        public RoomTypesController()
        {
            _roomTypesRepo = new RoomTypesRepo();
        }

        // GET: api/RoomTypes
        public IHttpActionResult Get()
        {
            var result = _roomTypesRepo.GetRoomTypes();
            return Json(result);
        }

        // GET: api/RoomTypes/ID
        public IHttpActionResult Get(int id)
        {
            var result = _roomTypesRepo.GetRoomTypeById(id);
            return Json(result);
        }

        // POST: api/RoomTypes
        public IHttpActionResult Post(RoomTypes roomType)
        {
            var result = _roomTypesRepo.AddRoomType(roomType);
            return Json(result);
        }

        // PUT: api/RoomTypes/ID
        public IHttpActionResult Put(int id, RoomTypes roomType)
        {
            roomType.RoomTypeId = id;
            var result = _roomTypesRepo.UpdateRoomType(roomType);
            return Json(result);
        }

        // DELETE: api/RoomTypes/ID
        public IHttpActionResult Delete(int id)
        {
            var result = _roomTypesRepo.DeleteRoomType(id);
            return Json(result);
        }
    }
}
