namespace JFS_Test.Models
{
    public class TurnoverStatement
    {
        public string PeriodName { get; set; }
        public decimal IncomingBalanceForPeriod { get; set; }
        public decimal AccruedForPeriod { get; set; }
        public decimal PaidForPeriod { get; set; }
        public decimal OutgoingBalanceForPeriod { get; set; }
    }
}
