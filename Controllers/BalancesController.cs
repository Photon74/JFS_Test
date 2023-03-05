using JFS_Test.DTOModels;
using JFS_Test.Repositories;
using JFS_Test.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JFS_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalancesController : ControllerBase
    {

        private readonly IStatementService _service;
        private readonly IRepository _repository;
        private readonly IPaymentService _paymentService;

        public BalancesController(IStatementService service, IRepository repository, IPaymentService paymentService)
        {
            _service = service;
            _repository = repository;
            _paymentService = paymentService;
        }

        // GET: api/<BalancesController>
        [HttpGet("/GetBalances")]
        public IEnumerable<TurnoverStatementDto> GetBalances(int accountId, Period period)
        {
            var result = _service.GetStatements(accountId, period);
            return result;
        }

        // Test
        [HttpGet("/get")]
        public IEnumerable<PaymentDto> Get(int accountId, Period period)
        {
            //string balanseJson = System.IO.File.ReadAllText("TestData/balance_202105270825.json");

            //var res = JsonSerializer.Deserialize<BalanceRoot>(balanseJson).Balances.ToList();
            //foreach (var item in res)
            //{
            //    var r = item;
            //}

            //string paymentJson = System.IO.File.ReadAllText("TestData/payment_202105270827.json");
            //using StreamReader sr = System.IO.File.OpenText(@"TestData/payment_202105270827.json");
            //JsonSerializer serializer = new JsonSerializer();

            //var paymentList = (List<Payment>)serializer.Deserialize(sr, typeof(List<Payment>));
            //foreach (var item in paymentList)
            //{
            //    var c = item;
            //}
            return _paymentService.GetPaymentDtoList();
        }
    }
}
