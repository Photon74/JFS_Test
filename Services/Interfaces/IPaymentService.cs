using JFS_Test.DTOModels;
using JFS_Test.Models;

namespace JFS_Test.Services.Interfaces
{
    public interface IPaymentService
    {
        IEnumerable<Payment> GetPayments();

        double GetSumForMonth(DateTimeOffset monthPeriod);

        double GetSumForPeriod(DateTimeOffset begin, DateTimeOffset end);

        IEnumerable<PaymentDto> GetPaymentDtoList();
    }
}
