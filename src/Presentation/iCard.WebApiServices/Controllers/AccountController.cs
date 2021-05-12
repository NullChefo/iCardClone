using iCard.ApplicationServices.DTOs;
using iCard.ApplicationServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace iCard.WebApiServices.Controllers
{
    public class AccountController : ControllerBase
    {
        private readonly AccountService _service = new AccountService();
        private readonly ExchangeService _exchangeService = new ExchangeService();

        [HttpGet, Route("api/user/{username}/account")]
        public OkObjectResult GetByUsername(string username)
        {
            return Ok(_service.GetAccount(username));
        }


        [HttpPost, Route("api/user/{username}/account")]
        public IActionResult AddAccount(string username, AccountDTO dto)
        {
            return Ok(_service.AddAccountToUser(dto, username));
        }

        [HttpPut, Route("api/user/{username}/account")]
        public IActionResult UpdateAccount(string username, AccountDTO dto)
        {
            return Ok(_service.UpdateAccount(dto, username));
        }
              
        
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("api/user/{username}/account/exchange")]
        public IActionResult Exchange(string username, ExchangeDTO dto)
        {
            return Ok(_exchangeService.ExchangeFromAccount(username, dto)); ;
        }

        

    }

}