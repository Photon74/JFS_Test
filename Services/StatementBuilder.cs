using JFS_Test.DTOModels;
using JFS_Test.Services.Interfaces;

namespace JFS_Test.Services
{
    public class StatementBuilder : IStatementBuilder
    {
        private StatementDto _statement;
        private IEnumerable<BalanceDto> _balances;

        public StatementBuilder()
        {
            _statement = null;
            _balances = null;
        }

        public StatementBuilder CreateStatement(IEnumerable<BalanceDto> balances)
        {
            _statement = new StatementDto();
            _balances = balances;

            return this;
        }

        public StatementBuilder AddName()
        {
            _statement.PeriodName = _balances.First().Period.ToString("MM - ")
                + _balances.Last().Period.ToString("MM/yyyy");

            return this;
        }

        public StatementBuilder AddIncomingBalance(double inBalance)
        {
            _statement.IncomingBalanceForPeriod = inBalance;

            return this;
        }

        public StatementBuilder AddCalculation(double calculation)
        {
            _statement.AccruedForPeriod = calculation;

            return this;
        }

        public StatementBuilder AddPaidSum(double sum)
        {
            _statement.PaidForPeriod = sum;

            return this;
        }

        public StatementBuilder AddOutcomingBalance(double outBalance)
        {
            _statement.OutgoingBalanceForPeriod = outBalance;

            return this;
        }

        public StatementDto GetStatement() => _statement;
    }
}
