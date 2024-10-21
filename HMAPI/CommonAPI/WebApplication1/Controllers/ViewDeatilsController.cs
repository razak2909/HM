using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using WebApplication1.DAO;
using WebApplication1.Models;
using WebApplication1.Repo;

namespace WebApplication1.Controllers
{
    public class ViewDetailsController : ApiController
    {
        private readonly ViewDetailsRepository _repository;

        public ViewDetailsController()
        {
            _repository = new ViewDetailsRepository(); // Use dependency injection in a real scenario
        }

        //// GET: api/ViewDetails
        //[HttpGet]
        //[Route("api/ViewDetails")]
        //public IEnumerable<ViewDetails> GetAll()
        //{
        //    return _repository.GetAll();
        //}

        // GET: api/ViewDetails/5
        [HttpGet]
        [Route("api/ViewDetails")]
        public IHttpActionResult Get(int id)
        {
            var details = _repository.GetById(id);
            if (details == null)
            {
                return NotFound();
            }
            return Ok(details);
        }

        //// POST: api/ViewDetails
        //[HttpPost]
        //[Route("api/ViewDetails")]
        //public IHttpActionResult Create([FromBody] ViewDetails details)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    _repository.Add(details);
        //    return CreatedAtRoute("DefaultApi", new { id = details.GuestId }, details);
        //}

        //// PUT: api/ViewDetails/5
        //[HttpPut]
        //[Route("api/ViewDetails/{id}")]
        //public IHttpActionResult Update(int id, [FromBody] ViewDetails details)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    if (id != details.GuestId)
        //        return BadRequest();

        //    _repository.Update(details);
        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// DELETE: api/ViewDetails/5
        //[HttpDelete]
        //[Route("api/ViewDetails/{id}")]
        //public IHttpActionResult Delete(int id)
        //{
        //    var details = _repository.GetById(id);
        //    if (details == null)
        //    {
        //        return NotFound();
        //    }

        //    _repository.Delete(id);
        //    return Ok(details);
        //}
    }
}
