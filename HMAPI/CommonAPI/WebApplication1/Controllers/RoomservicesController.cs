using HotelManagement.Models;
using HotelManagement.Repo;
using System.Web.Http;

namespace HotelManagement.Controllers
{
    public class RoomServicesController : ApiController
    {
        private readonly RoomServicesRepo _roomServicesRepo;

        public RoomServicesController()
        {
            _roomServicesRepo = new RoomServicesRepo();
        }

        // GET : api/RoomServices
        public IHttpActionResult Get()
        {
            var result = _roomServicesRepo.GetRoomServices();
            return Json(result);
        }

        // GET : api/RoomServices/ID
        public IHttpActionResult Get(int id)
        {
            var result = _roomServicesRepo.GetRoomServiceById(id);
            return Json(result);
        }

        // POST : api/RoomServices
        public IHttpActionResult Post(RoomService roomService)
        {
            var result = _roomServicesRepo.AddRoomService(roomService);
            return Json(result);
        }

        // PUT : api/RoomServices/ID
        public IHttpActionResult Put(int id, RoomService roomService)
        {
            roomService.ServiceId = id;
            var result = _roomServicesRepo.UpdateRoomService(roomService);
            return Json(result);
        }

        // DELETE : api/RoomServices/ID
        public IHttpActionResult Delete(int id)
        {
            var result = _roomServicesRepo.DeleteRoomService(id);
            return Json(result);
        }
    }
}
