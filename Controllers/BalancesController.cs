using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JFS_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalancesController : ControllerBase
    {
        private readonly string balanseJson = System.IO.File.ReadAllText("TestData/balance_202105270825.json");
        private readonly string paymentJson = System.IO.File.ReadAllText("TestData/payment_202105270827.json");

        //private readonly IRepository _repository;

        //public BalancesController(IRepository repository)
        //{
        //    _repository = repository;
        //}

        // GET: api/<BalancesController>
        [HttpGet]
        public List<Payment> GetBalances()
        {
            var res = JsonSerializer.Deserialize<BalanceRoot>(balanseJson);
            var b = res.Balances.ToList();
            foreach (var item in b)
            {
                var r = item;
            }

            var paymentList = JsonSerializer.Deserialize<List<Payment>>(paymentJson);
            foreach (var item in paymentList)
            {
                var c = item;
            }
            return paymentList;
            //return _repository.GetCalculations();
        }
    }
}
