using JFS_Test.DTOModels;
using JFS_Test.Repositories;
using JFS_Test.Services.Interfaces;

namespace JFS_Test.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IRepository _repository;

        public PaymentService(IRepository repository)
        {
            _repository = repository;
        }

        public double GetSumForMonth(DateTimeOffset monthPeriod)
        {

            var sum = GetPaymentDtoList()
                 .Where(p => p.Date.Year == monthPeriod.Year
                             && p.Date.Month == monthPeriod.Month)
                 .Sum(p => p.Sum);

            return sum;
        }

        public double GetSumForPeriod(DateTimeOffset begin, DateTimeOffset end)
        {
            var sum = GetPaymentDtoList()
                .Where(p => p.Date >= begin && p.Date <= end.AddMonths(1))
                .Sum(p => p.Sum);

            return sum;
        }

        private IEnumerable<PaymentDto> GetPaymentDtoList()
        {
            List<PaymentDto> paymentDtoList = new List<PaymentDto>();
            var payments = _repository.GetPayments();

            foreach (var payment in payments)
            {
                paymentDtoList.Add(new PaymentDto
                {
                    AccountId = payment.AccountId,
                    Date = DateTimeOffset.Parse(payment.Date),
                    Sum = payment.Sum,
                    PaymentGuid = payment.PaymentGuid
                });
            }

            return paymentDtoList;
        }
    }
}
