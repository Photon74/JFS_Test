﻿using JFS_Test.DTOModels;
using JFS_Test.DTOModels.Enums;
using JFS_Test.Services.Interfaces;
using System.Text;

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

        public StatementBuilder AddName(Period period)
        {
            StringBuilder sb = new StringBuilder();
            if (period == Period.Month)
            {
                sb.Append("Отчет за месяц: ");
            }
            else if (period == Period.Quarter)
            {
                sb.Append("Отчет за квартал: ");
            }
            else sb.Append("Отчет за год: ");

            sb.Append(_balances.FirstOrDefault().Period.ToString("MM - ")
                + _balances.LastOrDefault().Period.ToString("MM.yyyy"));

            _statement.PeriodName = sb.ToString();

            return this;
        }

        public StatementBuilder AddIncomingBalance(double inBalance)
        {
            _statement.IncomingBalanceForPeriod = inBalance;

            return this;
        }

        public StatementBuilder AddCalculation(double calculation)
        {
            _statement.CalculatedForPeriod = calculation;

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
