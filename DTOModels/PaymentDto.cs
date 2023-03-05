namespace JFS_Test.DTOModels
{
    public class PaymentDto
    {
        public int AccountId { get; set; }

        public DateTimeOffset Date { get; set; }

        public double Sum { get; set; }

        public string PaymentGuid { get; set; }
    }
}
