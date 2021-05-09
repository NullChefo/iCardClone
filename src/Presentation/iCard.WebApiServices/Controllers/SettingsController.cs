using System.Web.Http;
using iCard.ApplicationServices.DTOs;
using iCard.ApplicationServices.Services;

namespace iCard.WebApiServices.Controllers
{
    public class SettingsController : ApiController
    {
        private readonly SettingsService _service = new SettingsService();

        [HttpGet, Route("api/user/{username}/account/settings")]
        public IHttpActionResult GetSettings(string username)
        {
            return Json(_service.GetSettings(username));
        }


        [HttpPut, Route("api/user/{username}/account/settings")]
        public IHttpActionResult UpdateSettings(string username, SettingsDTO dto)
        {
            return Json(_service.UpdateSettings(username, dto));
        }


    }

}