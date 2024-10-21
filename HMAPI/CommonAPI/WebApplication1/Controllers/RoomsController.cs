using HotelManagement.Models;
using HotelManagement.Repo;
using System.Web.Http;
using WebApplication1.Models;

namespace HotelManagement.Controllers
{
    public class RoomsController : ApiController
    {
        private readonly RoomsRepository _roomsRepository;

        public RoomsController()
        {
            _roomsRepository = new RoomsRepository();
        }

        // GET : api/Rooms
        public IHttpActionResult Get()
        {
            var result = _roomsRepository.GetRooms();
            return Json(result);
        }
      

        //to get the Room Number by selecting the Room Type
        [HttpGet]
        [Route("api/EmptyRoomNumber")]
        public IHttpActionResult getRooms(int RoomTypeId)
        {
            var result = _roomsRepository.GetRoomType(RoomTypeId);
            return Ok(result);
        }

        // GET : api/Rooms/ID
        public IHttpActionResult Get(int id)
        {
            var result = _roomsRepository.GetRoomById(id);
            return Json(result);
        }

        // POST : api/Rooms
        public IHttpActionResult Post(RoomsModel room)
        {
            var result = _roomsRepository.AddRoom(room);
            return Json(result);
        }

        // PUT : api/Rooms/ID

        public IHttpActionResult Put(int id , RoomsModel room)
        {
            room.RoomId = id;
            room.LatestService = System.DateTime.Now;
            var result = _roomsRepository.UpdateRoom(room);
            return Json(result);
        }

        // DELETE : api/Rooms/ID
        public IHttpActionResult Delete(int id)
        {
            var result = _roomsRepository.DeleteRoom(id);
            return Json(result);
        }

        [AllowAnonymous]
        [Route("api/AllDashboardData")]

        public IHttpActionResult GetAll()
        {
            var obj = new RoomsRepository();
            return Ok(obj.GetDashboardDataRepository());



        }
    }
}
