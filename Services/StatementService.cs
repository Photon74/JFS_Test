using JFS_Test.DTOModels;
using JFS_Test.DTOModels.Enums;
using JFS_Test.Services.Interfaces;

namespace JFS_Test.Services
{
    public class StatementService : IStatementService
    {
        private readonly IPaymentService _paymentService;
        private readonly IBalanceService _balanceService;
        private readonly IStatementBuilder _statementBuilder;

        public StatementService(IPaymentService paymentService, IBalanceService balanceService, IStatementBuilder statementBuilder)
        {
            _paymentService = paymentService;
            _balanceService = balanceService;
            _statementBuilder = statementBuilder;
        }

        public IEnumerable<StatementDto> GetStatements(int accountId, Period period)
        {
            var statements = new List<StatementDto>();
            var balances = _balanceService.GetBalancesByAccountId(accountId);

            for (var i = 0; i < balances.Count(); i += (int)period)
            {
                var balancePeriod = balances.Skip(i).Take(((int)period)).ToList();
                var statement = BuildStatementIn(balancePeriod);
                statements.Add(statement);
            }

            return statements;
        }

        private StatementDto BuildStatementIn(List<BalanceDto> balancePeriod)
        {
            var incomingBalance = balancePeriod.FirstOrDefault().InBalance;
            var accruedForPeriod = _paymentService.GetSumForPeriod(
                balancePeriod.FirstOrDefault().Period,
                balancePeriod.LastOrDefault().Period);
            var paidForPeriod = balancePeriod.Sum(b => b.Calculation);
            var outgoingBalance = incomingBalance + paidForPeriod - accruedForPeriod;

            var statement = _statementBuilder
                .CreateStatement(balancePeriod)
                .AddName()
                .AddIncomingBalance(Math.Round(incomingBalance, 2))
                .AddCalculation(Math.Round(accruedForPeriod, 2))
                .AddPaidSum(Math.Round(paidForPeriod, 2))
                .AddOutcomingBalance(Math.Round(outgoingBalance, 2))
                .GetStatement();

            return statement;
        }
    }
}
