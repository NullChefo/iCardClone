using iCard.ApplicationServices.DTOs;
using iCard.ApplicationServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace iCard.WebApiServices.Controllers
{
    // [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly SettingsService _service = new SettingsService();

        [HttpGet, Route("api/user/{username}/account/settings")]
        public IActionResult GetSettings(string username)
        {
            return Ok(_service.GetSettings(username));
        }


        [HttpPut, Route("api/user/{username}/account/settings")]
        public IActionResult UpdateSettings(string username, SettingsDTO dto)
        {
            return Ok(_service.UpdateSettings(username, dto));
        }


    }

}