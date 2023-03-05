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
                var balanceDtos = balances.Skip(i).Take(((int)period)).ToList();
                var statement = BuildStatementIn(balanceDtos, period);
                statements.Add(statement);
            }

            return statements;
        }

        private StatementDto BuildStatementIn(List<BalanceDto> balanceDtos, Period period)
        {
            var incomingBalance = balanceDtos.FirstOrDefault().InBalance;
            var calculatedForPeriod = balanceDtos.Sum(s => s.Calculation);
            var paidForPeriod = _paymentService.GetSumForPeriod(
                balanceDtos.FirstOrDefault().Period,
                balanceDtos.LastOrDefault().Period);
            var outgoingBalance = incomingBalance - calculatedForPeriod + paidForPeriod;

            var statement = _statementBuilder
                .CreateStatement(balanceDtos)
                .AddName(period)
                .AddIncomingBalance(Math.Round(incomingBalance, 2))
                .AddCalculation(Math.Round(calculatedForPeriod, 2))
                .AddPaidSum(Math.Round(paidForPeriod, 2))
                .AddOutcomingBalance(Math.Round(outgoingBalance, 2))
                .GetStatement();

            return statement;
        }
    }
}
