using HotelManagement.Models;
using HotelManagement.Repo;
using System.Web.Http;

namespace HotelManagement.Controllers
{
    public class PaymentsController : ApiController
    {
        private readonly PaymentsRepo _paymentsRepo;

        public PaymentsController()
        {
            _paymentsRepo = new PaymentsRepo();
        }

        // GET: api/Payments
        public IHttpActionResult Get()
        {
            var result = _paymentsRepo.GetPayments();
            return Json(result);
        }

        // GET: api/Payments/ID
        public IHttpActionResult Get(int id)
        {
            var result = _paymentsRepo.GetPaymentById(id);
            return Json(result);
        }

        // POST: api/Payments
        public IHttpActionResult Post(Payment payment)
        {
            var result = _paymentsRepo.AddPayment(payment);
            return Json(result);
        }

        // PUT: api/Payments/ID
        public IHttpActionResult Put(int id, Payment payment)
        {
            payment.PaymentId = id;
            var result = _paymentsRepo.UpdatePayment(payment);
            return Json(result);
        }

        // DELETE: api/Payments/ID
        public IHttpActionResult Delete(int id)
        {
            var result = _paymentsRepo.DeletePayment(id);
            return Json(result);
        }
    }
}
 