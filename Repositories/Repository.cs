using JFS_Test.Models;
using System.Text.Json;

namespace JFS_Test.Repositories
{
    public class Repository : IRepository
    {
        private readonly string balanseJson = File.ReadAllText("TestData/balance_202105270825.json");
        private readonly string paymentJson = File.ReadAllText("TestData/payment_202105270827.json");

        public IEnumerable<Balance> GetBalances()
        {
            var balanceRoot = JsonSerializer.Deserialize(balanseJson, typeof(BalanceRoot)) as BalanceRoot;
            return balanceRoot.Balances.ToList();
        }

        public IEnumerable<Payment> GetPayments()
        {
            var paymentList = JsonSerializer.Deserialize(paymentJson, typeof(IEnumerable<Payment>)) as IEnumerable<Payment>;
            return paymentList;
        }
    }
}
