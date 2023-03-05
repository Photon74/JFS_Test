using JFS_Test.DTOModels;
using JFS_Test.DTOModels.Enums;

namespace JFS_Test.Services.Interfaces
{
    public interface IStatementBuilder
    {
        public StatementBuilder CreateStatement(IEnumerable<BalanceDto> balances);

        public StatementBuilder AddName(Period period);

        public StatementBuilder AddIncomingBalance(double inBalance);

        public StatementBuilder AddCalculation(double calculation);

        public StatementBuilder AddPaidSum(double sum);

        public StatementBuilder AddOutcomingBalance(double outBalance);

        public StatementDto GetStatement();
    }
}
