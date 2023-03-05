namespace JFS_Test.DTOModels
{
    public class BalanceDto
    {
        public int AccountId { get; set; }

        public DateTimeOffset Period { get; set; }

        public double InBalance { get; set; }

        public double Calculation { get; set; }
    }
}
