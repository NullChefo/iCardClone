using System.Web.Http;
using iCard.ApplicationServices.Services;

namespace iCard.WebApiServices.Controllers
{
    public class TransactionHistoryController : ApiController
    {
        private readonly TransactionHistoryService _service = new TransactionHistoryService();

        [HttpGet, Route("api/user/{username}/account/transactions")]
        public IHttpActionResult GetTransactions(string username)
        {
            return Json(_service.GetTransactionsForAccount(username));
        }


        [HttpGet, Route("api/user/{username}/account/transactions/virtual-card/{cardname}")]
        public IHttpActionResult GetTransactionForVirtualCard(string username, string cardname)
        {
            return Json(_service.GetTransactionsForVirtualCard(username, cardname));
        }

    }
}