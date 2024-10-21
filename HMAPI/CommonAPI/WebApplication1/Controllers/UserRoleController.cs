using Newtonsoft.Json;
using System.Web;
using System.Web.Http;
using WebApplication1.Helpers;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Log]
    [Authorize]
    public class UserRoleController : ApiController
    {
        private readonly UserRoleRepository _userRoleRepo;

        public UserRoleController()
        {
            _userRoleRepo = new UserRoleRepository();
        }

        public IHttpActionResult GetUserRole()
        {
            var result = _userRoleRepo.GetAllUserRole();
            return Ok(result);
        }

        public IHttpActionResult PostUserRole()
        {
            UserRoleModel mdl = JsonConvert.DeserializeObject<UserRoleModel>(HttpContext.Current.Request.Form["JsonObjStr"]);
            var result = _userRoleRepo.PostUserRole(mdl);
            return Ok(result);
        }
    }

}
