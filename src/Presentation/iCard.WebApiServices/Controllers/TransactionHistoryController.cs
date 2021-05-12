using iCard.ApplicationServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace iCard.WebApiServices.Controllers
{
  //  [Route("api/[controller]")]
    [ApiController]
    public class TransactionHistoryController : ControllerBase
    {
        private readonly TransactionHistoryService _service = new TransactionHistoryService();

        [HttpGet, Route("api/user/{username}/account/transactions")]
        public IActionResult GetTransactions(string username)
        {
            return Ok(_service.GetTransactionsForAccount(username));
        }


        [HttpGet, Route("api/user/{username}/account/transactions/virtual-card/{cardname}")]
        public IActionResult GetTransactionForVirtualCard(string username, string cardname)
        {
            return Ok(_service.GetTransactionsForVirtualCard(username, cardname));
        }

    }
}