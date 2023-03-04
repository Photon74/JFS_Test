﻿using System.Text.Json;

namespace JFS_Test.Repositories
{
    public class Repository : IRepository
    {
        private readonly string balanseJson = File.ReadAllText("TestData/balance_202105270825.json");
        private readonly string paymentJson = File.ReadAllText("TestData/payment_202105270827.json");

        public BalanceRoot GetCalculations()
        {
            return JsonSerializer.Deserialize<BalanceRoot>(balanseJson);
        }

        public IEnumerable<Payment> GetPayments()
        {
            return JsonSerializer.Deserialize<List<Payment>>(balanseJson);
        }
    }
}