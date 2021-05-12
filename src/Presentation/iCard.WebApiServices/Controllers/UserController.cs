
using iCard.ApplicationServices.DTOs;
using iCard.ApplicationServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace iCard.WebApiServices.Controllers
{
   // [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _service = new UserService();

        [HttpGet, Route("api/user/{username}")]
        public IActionResult GetByUsername(string username)
        {           
            return Ok(_service.GetByUsername(username));
        }

               
        [HttpPost, Route("api/user/register")]
        public IActionResult Register(UserDTO user)
        {           
            return Ok(_service.CreateUser(user));
        }
               
        [HttpPut, Route("api/user")]
        public IActionResult Update(UserDTO user)
        {           
            return Ok(_service.UpdateUser(user));
        }



    }

}