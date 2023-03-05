namespace JFS_Test.DTOModels
{
    public class StatementDto
    {
        public string PeriodName { get; set; }
        public double IncomingBalanceForPeriod { get; set; }
        public double AccruedForPeriod { get; set; }
        public double PaidForPeriod { get; set; }
        public double OutgoingBalanceForPeriod { get; set; }
    }
}
