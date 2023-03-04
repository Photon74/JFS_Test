using System.Text.Json.Serialization;

namespace JFS_Test.Models
{
    public class Payment
    {
        [JsonPropertyName("account_id")]
        public int AccountId { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("sum")]
        public double Sum { get; set; }

        [JsonPropertyName("payment_guid")]
        public string PaymentGuid { get; set; }
    }
}
