using AutoMapper;
using JFS_Test.DTOModels;
using JFS_Test.Models;
using JFS_Test.Repositories;
using JFS_Test.Services.Interfaces;

namespace JFS_Test.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public PaymentService(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<Payment> GetPayments()
        {
            return _repository.GetPayments();
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

        public double GetSumMonth(DateTimeOffset month)
        {
            var sum = GetPaymentDtoList()
                .Where(p => p.Date.Year > month.Year
                && p.Date.Month == month.Month)
                .Sum(p => p.Sum);

            return sum;
        }

        public IEnumerable<PaymentDto> GetPaymentDtoList()
        {
            List<PaymentDto> paymentDtoList = new List<PaymentDto>();
            var payments = _repository.GetPayments();

            foreach (var payment in payments)
            {
                paymentDtoList.Add(_mapper.Map<PaymentDto>(payment));
            }

            return paymentDtoList;
        }
    }
}
