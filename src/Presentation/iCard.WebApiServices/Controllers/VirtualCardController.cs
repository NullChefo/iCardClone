using iCard.ApplicationServices.Converters;
using iCard.ApplicationServices.DTOs;
using iCard.ApplicationServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace iCard.WebApiServices.Controllers
{
 //   [Route("api/[controller]")]
    [ApiController]
      public class VirtualCardController : ControllerBase
    {
        private readonly VirtualCardService _service = new VirtualCardService();
        private readonly ExchangeService exchangeService = new ExchangeService();


        [HttpGet, Route("api/user/{username}/virtual-card")]
        public IActionResult GetAllVirtualCards(string username)
        {
            return Ok(_service.GetVirtualCards(username));
        }
            
        [HttpGet, Route("api/user/{username}/virtual-card/{cardname}")]
        public IActionResult GetAllVirtualCards(string username, string cardname)
        {
            return Ok(VirtualCardConverter.ToDTO(_service.GetVirtualCard(username, cardname)));
        }
               
        [HttpGet, Route("api/user/{username}/virtual-card/{cardnumber}/search")]
        public IActionResult GetVirtualCardByCardNumber(string username, string cardnumber)
        {
            return Ok(_service.GetVirtualCardByCardNumber(username, cardnumber));
        }


        [HttpPost, Route("api/user/{username}/virtual-card")]
        public IActionResult AddVitualCard(string username, VirtualCardDTO dto)
        {
            return Ok(_service.AddVirtualCard(username, dto));
        }
               
        
        [HttpPost, Route("api/user/{username}/virtual-card/{cardname}/deposit")]
        public IActionResult AddDepositToVitualCard(string username, string cardname, DepositDTO dto)
        {
            return Ok(_service.DepositToVirtualCard(username, cardname,  dto));
        }

               
        [HttpPost, Route("api/user/{username}/virtual-card/{cardname}/withdraw")]
        public IActionResult WithdrawFromVitualCard(string username, string cardname, WithdrawDTO dto)
        {
            return Ok(_service.WithdrawFromVirtualCard(username, cardname,  dto));
        }

               
        [HttpPost, Route("api/user/{username}/virtual-card/{cardname}/transfer")]
        public IActionResult TransferFromAccount(string username, string cardname, DepositDTO dto)
        {
            return Ok(_service.TransferFromAccount(username, cardname,  dto));
        }               
       
        [HttpPost, Route("api/user/{username}/virtual-card/{cardname}/exchange")]
        public IActionResult Exchange(string username, string cardname, ExchangeDTO dto)
        {
            return Ok(exchangeService.ExchangeFromVirtualCard(username, cardname,  dto));
        }


    }

}