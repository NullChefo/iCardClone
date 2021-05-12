using iCard.ApplicationServices.DTOs;
using iCard.ApplicationServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace iCard.WebApiServices.Controllers
{
    // [Route("api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private readonly PlanService _service = new PlanService();

        [HttpGet, Route("api/user/{username}/account/plan")]
        public IActionResult GetPlan(string username)
        {
            return Ok(_service.GetPlanDetails(username));
        }


        [HttpPut, Route("api/user/{username}/account/plan")]
        public IActionResult UpdateAccount(string username, PlanDTO dto)
        {
            return Ok(_service.UpdatePlan(username, dto));
        }


        [HttpPost, Route("api/user/{username}/account/plan/recharge")]
        public IActionResult AddAccount(string username)
        {
            _service.RechargeTransactions(username);
            return Ok("DONE!");
        }

    }

}