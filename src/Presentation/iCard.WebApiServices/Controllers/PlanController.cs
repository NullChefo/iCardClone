using System.Web.Http;
using iCard.ApplicationServices.DTOs;
using iCard.ApplicationServices.Services;

namespace iCard.WebApiServices.Controllers
{
    public class PlanController : ApiController
    {
        private readonly PlanService _service = new PlanService();

        [HttpGet, Route("api/user/{username}/account/plan")]
        public IHttpActionResult GetPlan(string username)
        {
            return Json(_service.GetPlanDetails(username));
        }


        [HttpPut, Route("api/user/{username}/account/plan")]
        public IHttpActionResult UpdateAccount(string username, PlanDTO dto)
        {
            return Json(_service.UpdatePlan(username, dto));
        }


        [HttpPost, Route("api/user/{username}/account/plan/recharge")]
        public IHttpActionResult AddAccount(string username)
        {
            _service.RechargeTransactions(username);
            return Json("DONE!");
        }

    }

}