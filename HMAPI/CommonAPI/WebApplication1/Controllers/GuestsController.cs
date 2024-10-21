using HotelManagement.Models;
using HotelManagement.Repo;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace HotelManagement.Controllers
{
    public class GuestsController : ApiController
    {
        private readonly GuestsRepo _guestsRepo;

        public GuestsController()
        {
            _guestsRepo = new GuestsRepo();
        }

        // GET: api/Guests
        public IHttpActionResult Get()
        {
            var result = _guestsRepo.GetGuests();
            return Json(result);
        }

        // GET: api/Guests/ID
        public IHttpActionResult Get(int id)
        {
            var result = _guestsRepo.GetGuestById(id);
            return Json(result);
        }

        // POST: api/Guests

        [HttpPost]
        [Route("api/addBooking")]
        public IHttpActionResult Post()
        {
            
            var httpRequest = HttpContext.Current.Request;

            var guest = JsonConvert.DeserializeObject<Guest>(httpRequest.Form["JsonObjStr"]);

            ClaimsIdentity identity = User.Identity as ClaimsIdentity;

            var mappedPath = System.Web.Hosting.HostingEnvironment.MapPath("~/ProjectFiles/GuestIdProof/");
            if (!System.IO.Directory.Exists(mappedPath))
                System.IO.Directory.CreateDirectory(mappedPath);

            string profilePhoto = "";
            DateTime currentDate = DateTime.Now;
            var files = httpRequest.Files;
            for (int i = 0; i < files.AllKeys.Length; i++)
            {
                string fileKey = files.AllKeys[i];
                if (fileKey == "DocumentName")
                {
                    var postedFile = httpRequest.Files[files.AllKeys[i]];
                    using (var binaryReader = new BinaryReader(postedFile.InputStream))
                    {
                        var bts = binaryReader.ReadBytes(postedFile.ContentLength);
                        if (bts != null && bts.Length > 0)
                        {
                            profilePhoto = guest.IdProofNumber + currentDate.ToString("dd_MMM_yyyy_HH_mm_ss") + Path.GetExtension(postedFile.FileName);

                            var path = Path.Combine(mappedPath, profilePhoto);
                            File.WriteAllBytes(path, bts);
                        }
                    }
                }
            }

            guest.IDProofPhoto = profilePhoto;




            var result = _guestsRepo.AddGuest(guest);
            return Json(result);
        }

        // PUT: api/Guests/ID
        public IHttpActionResult Put(int id, Guest guest)
        {
            guest.GuestId = id;
            var result = _guestsRepo.UpdateGuest(guest);
            return Json(result);
        }

        // DELETE: api/Guests/ID
        public IHttpActionResult Delete(int id)
        {
            var result = _guestsRepo.DeleteGuest(id);
            return Json(result);
        }
    }
}
