using System.Web.Http;
using WebApplication1.Helpers;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Log]
    [Authorize]
    public class UserLevelController : ApiController
    {
        private readonly UserLevelRepository _userLevelRepo;

        public UserLevelController()
        {
            _userLevelRepo = new UserLevelRepository();
        }

        public IHttpActionResult GetUserLevel()
        {
            var result = _userLevelRepo.GetAllUserLevel();
            return Ok(result);
        }
    }
}
