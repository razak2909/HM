using HotelManagement.Models;
using HotelManagement.Repo;
using System.Web.Http;

namespace HotelManagement.Controllers
{
    public class StaffsController : ApiController
    {
        private readonly StaffsRepo _staffsRepo;

        public StaffsController()
        {
            _staffsRepo = new StaffsRepo();
        }

        // GET: api/Staffs
        public IHttpActionResult Get()
        {
            var result = _staffsRepo.GetStaffs();
            return Json(result);
        }

        // GET: api/Staffs/ID
        public IHttpActionResult Get(int id)
        {
            var result = _staffsRepo.GetStaffById(id);
            return Json(result);
        }

        // POST: api/Staffs
        public IHttpActionResult Post(Staff staff)
        {
            var result = _staffsRepo.AddStaff(staff);
            return Json(result);
        }

        // PUT: api/Staffs/ID
        public IHttpActionResult Put(int id, Staff staff)
        {
            staff.StaffId = id;
            var result = _staffsRepo.UpdateStaff(staff);
            return Json(result);
        }

        // DELETE: api/Staffs/ID
        public IHttpActionResult Delete(int id)
        {
            var result = _staffsRepo.DeleteStaff(id);
            return Json(result);
        }
    }
}
