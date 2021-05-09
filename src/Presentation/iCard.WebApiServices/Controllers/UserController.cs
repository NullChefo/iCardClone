using System.Web.Http;
using iCard.ApplicationServices.DTOs;
using iCard.ApplicationServices.Services;

namespace iCard.WebApiServices.Controllers
{
    public class UserController : ApiController
    {
        private readonly UserService _service = new UserService();

        [HttpGet, Route("api/user/{username}")]
        public IHttpActionResult GetByUsername(string username)
        {           
            return Json(_service.GetByUsername(username));
        }

               
        [HttpPost, Route("api/user/register")]
        public IHttpActionResult Register(UserDTO user)
        {           
            return Json(_service.CreateUser(user));
        }
               
        [HttpPut, Route("api/user")]
        public IHttpActionResult Update(UserDTO user)
        {           
            return Json(_service.UpdateUser(user));
        }



    }

}