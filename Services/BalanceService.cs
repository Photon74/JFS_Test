using JFS_Test.DTOModels;
using JFS_Test.Repositories;
using JFS_Test.Services.Interfaces;

namespace JFS_Test.Services
{
    public class BalanceService : IBalanceService
    {
        private readonly IRepository _repository;
        private readonly IPaymentService _paymentService;

        public BalanceService(IRepository repository, IPaymentService paymentService)
        {
            _repository = repository;
            _paymentService = paymentService;
        }

        public IEnumerable<BalanceDto> GetBalancesByAccountId(int accountId)
        {
            var balances = GetBalances()
                .Where(b => b.AccountId == accountId)
                .ToList();

            var recalculated = RecalculateBalance(balances).OrderBy(x => x.Period);

            return recalculated;
        }

        private IEnumerable<BalanceDto> GetBalances()
        {
            var balanceDtoList = new List<BalanceDto>();
            var balances = _repository.GetBalances();
            foreach (var balance in balances)
            {
                balanceDtoList.Add(new BalanceDto
                {
                    AccountId = balance.AccountId,
                    Calculation = balance.Calculation,
                    InBalance = balance.InBalance,
                    Period = DateTimeOffset.ParseExact(balance.Period.ToString(), "yyyyMM", null),
                });
            }

            return balanceDtoList;
        }

        private IEnumerable<BalanceDto> RecalculateBalance(List<BalanceDto> balances)
        {
            for (var i = 0; i < balances.Count(); i++)
            {
                double incomingBalance;
                var currBalance = balances[i];
                var currSum = _paymentService.GetSumForMonth(currBalance.Period);

                if (i == 0)
                {
                    var nextBalance = balances[i + 1];
                    incomingBalance = nextBalance.InBalance - currBalance.InBalance + currSum;
                    balances[i].InBalance = incomingBalance;

                    continue;
                }

                var prevBalance = balances[i - 1];
                var prevSum = _paymentService.GetSumForMonth(prevBalance.Period);
                incomingBalance = prevBalance.InBalance + prevBalance.Calculation - prevSum;
                balances[i].InBalance = incomingBalance;
            }

            return balances;
        }
    }
}
