using HotelManagement.Models;
using HotelManagement.Repo;
using System.Web.Http;

namespace HotelManagement.Controllers
{
    public class StaffDocumentController : ApiController
    {
        private readonly StaffDocumentRepo _staffDocumentRepo;

        public StaffDocumentController()
        {
            _staffDocumentRepo = new StaffDocumentRepo();
        }

        // GET: api/StaffDocument
        public IHttpActionResult Get()
        {
            var result = _staffDocumentRepo.GetStaffDocuments();
            return Json(result);
        }

        // GET: api/StaffDocument/ID
        public IHttpActionResult Get(int id)
        {
            var result = _staffDocumentRepo.GetStaffDocumentById(id);
            return Json(result);
        }

        // POST: api/StaffDocument
        public IHttpActionResult Post(StaffDocument staffDocument)
        {
            var result = _staffDocumentRepo.AddStaffDocument(staffDocument);
            return Json(result);
        }

        // PUT: api/StaffDocument/ID
        public IHttpActionResult Put(int id, StaffDocument staffDocument)
        {
            staffDocument.DocumentsId = id;
            var result = _staffDocumentRepo.UpdateStaffDocument(staffDocument);
            return Json(result);
        }

        // DELETE: api/StaffDocument/ID
        public IHttpActionResult Delete(int id)
        {
            var result = _staffDocumentRepo.DeleteStaffDocument(id);
            return Json(result);
        }
    }
}
