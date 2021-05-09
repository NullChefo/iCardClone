using System.Web.Http;
using System.Web.Http.Results;
using iCard.ApplicationServices.DTOs;
using iCard.ApplicationServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace iCard.WebApiServices.Controllers
{
    public class AccountController : ApiController
    {
        private readonly AccountService _service = new AccountService();
        private readonly ExchangeService _exchangeService = new ExchangeService();

        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("api/user/{username}/account")]
        public JsonResult<AccountDTO> GetByUsername(string username)
        {
            return Json(_service.GetAccount(username));
        }


        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("api/user/{username}/account")]
        public IHttpActionResult AddAccount(string username, AccountDTO dto)
        {
            return Json(_service.AddAccountToUser(dto, username));
        }

        [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("api/user/{username}/account")]
        public IHttpActionResult UpdateAccount(string username, AccountDTO dto)
        {
            return Json(_service.UpdateAccount(dto, username));
        }
              
        
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("api/user/{username}/account/exchange")]
        public IHttpActionResult Exchange(string username, ExchangeDTO dto)
        {
            return Json(_exchangeService.ExchangeFromAccount(username, dto)); ;
        }

        

    }

}