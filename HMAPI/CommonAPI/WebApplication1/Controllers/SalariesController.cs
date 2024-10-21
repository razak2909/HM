using HotelManagement.Models;
using HotelManagement.Repo;
using System.Web.Http;

namespace HotelManagement.Controllers
{
    public class SalariesController : ApiController
    {
        private readonly SalariesRepo _salariesRepo;

        public SalariesController()
        {
            _salariesRepo = new SalariesRepo();
        }

        // GET: api/Salaries
        public IHttpActionResult Get()
        {
            var result = _salariesRepo.GetSalaries();
            return Json(result);
        }

        // GET: api/Salaries/ID
        public IHttpActionResult Get(int id)
        {
            var result = _salariesRepo.GetSalaryById(id);
            return Json(result);
        }

        // POST: api/Salaries
        public IHttpActionResult Post(Salaries salary)
        {
            var result = _salariesRepo.AddSalary(salary);
            return Json(result);
        }

        // PUT: api/Salaries/ID
        public IHttpActionResult Put(int id, Salaries salary)
        {
            salary.StaffId = id;
            var result = _salariesRepo.UpdateSalary(salary);
            return Json(result);
        }

        // DELETE: api/Salaries/ID
        public IHttpActionResult Delete(int id)
        {
            var result = _salariesRepo.DeleteSalary(id);
            return Json(result);
        }
    }
}
