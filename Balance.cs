using System.Text.Json.Serialization;

namespace JFS_Test
{
    public class Balance
    {
        [JsonPropertyName("account_id")]
        public int AccountId { get; set; }

        [JsonPropertyName("period")]
        public int Period { get; set; }

        [JsonPropertyName("in_balance")]
        public double InBalance { get; set; }

        [JsonPropertyName("calculation")]
        public double Calculation { get; set; }
    }

    public class BalanceRoot
    {
        [JsonPropertyName("balance")]
        public List<Balance> Balance { get; set; }
    }

}
