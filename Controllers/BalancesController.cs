using JFS_Test.DTOModels;
using JFS_Test.DTOModels.Enums;
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

        [HttpGet("/GetBalances")]
        //public IEnumerable<StatementDto> GetBalances(int accountId, Period period)
        //{
        //    var result = _service.GetStatements(accountId, period);
        //    return result.Reverse();
        //}
        public IEnumerable<StatementDto> GetBalances(int accountId, Period period) =>
            _service.GetStatements(accountId, period).Reverse();
    }
}
