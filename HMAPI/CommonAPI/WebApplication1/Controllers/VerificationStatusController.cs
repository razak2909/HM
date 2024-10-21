using System.Web.Http;
using WebApplication1.Helpers;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Log]
    [Authorize]
    public class VerificationStatusController : ApiController
    {
        private readonly VerificationStatusRepository _verificationStatusRepo;

        public VerificationStatusController()
        {
            _verificationStatusRepo = new VerificationStatusRepository();
        }

        public IHttpActionResult GetVerificationStatus()
        {
            var result = _verificationStatusRepo.GetVerificationStatus();
            return Ok(result);
        }
    }
}
