using JFS_Test.DTOModels;
using JFS_Test.Repositories;
using JFS_Test.Services.Interfaces;

namespace JFS_Test.Services
{
    public class StatementService : IStatementService
    {
        private readonly IRepository _repository;
        private readonly IPaymentService _paymentService;

        public StatementService(IRepository repository, IPaymentService paymentService)
        {
            _repository = repository;
            var balances = _repository.GetBalances();
            _paymentService = paymentService;
        }

        public IEnumerable<TurnoverStatementDto> GetStatements(int accountId, Period period)
        {

            return new List<TurnoverStatementDto>();
        }

        public double PaymentSum(int accountId, Period period)
        {
            var payments = _paymentService.GetPaymentDtoList();
            var t = payments.Where(p => p.Date == DateTime.Now);
            return 100;
        }
    }
}
