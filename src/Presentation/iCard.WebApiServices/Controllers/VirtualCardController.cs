using System.Web.Http;
using iCard.ApplicationServices.Converters;
using iCard.ApplicationServices.DTOs;
using iCard.ApplicationServices.Services;

namespace iCard.WebApiServices.Controllers
{
      public class VirtualCardController : ApiController
    {
        private readonly VirtualCardService _service = new VirtualCardService();
        private readonly ExchangeService exchangeService = new ExchangeService();


        [HttpGet, Route("api/user/{username}/virtual-card")]
        public IHttpActionResult GetAllVirtualCards(string username)
        {
            return Json(_service.GetVirtualCards(username));
        }
            
        [HttpGet, Route("api/user/{username}/virtual-card/{cardname}")]
        public IHttpActionResult GetAllVirtualCards(string username, string cardname)
        {
            return Json(VirtualCardConverter.ToDTO(_service.GetVirtualCard(username, cardname)));
        }
               
        [HttpGet, Route("api/user/{username}/virtual-card/{cardnumber}/search")]
        public IHttpActionResult GetVirtualCardByCardNumber(string username, string cardnumber)
        {
            return Json(_service.GetVirtualCardByCardNumber(username, cardnumber));
        }


        [HttpPost, Route("api/user/{username}/virtual-card")]
        public IHttpActionResult AddVitualCard(string username, VirtualCardDTO dto)
        {
            return Json(_service.AddVirtualCard(username, dto));
        }
               
        
        [HttpPost, Route("api/user/{username}/virtual-card/{cardname}/deposit")]
        public IHttpActionResult AddDepositToVitualCard(string username, string cardname, DepositDTO dto)
        {
            return Json(_service.DepositToVirtualCard(username, cardname,  dto));
        }

               
        [HttpPost, Route("api/user/{username}/virtual-card/{cardname}/withdraw")]
        public IHttpActionResult WithdrawFromVitualCard(string username, string cardname, WithdrawDTO dto)
        {
            return Json(_service.WithdrawFromVirtualCard(username, cardname,  dto));
        }

               
        [HttpPost, Route("api/user/{username}/virtual-card/{cardname}/transfer")]
        public IHttpActionResult TransferFromAccount(string username, string cardname, DepositDTO dto)
        {
            return Json(_service.TransferFromAccount(username, cardname,  dto));
        }               
       
        [HttpPost, Route("api/user/{username}/virtual-card/{cardname}/exchange")]
        public IHttpActionResult Exchange(string username, string cardname, ExchangeDTO dto)
        {
            return Json(exchangeService.ExchangeFromVirtualCard(username, cardname,  dto));
        }


    }

}