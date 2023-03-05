using AutoMapper;
using JFS_Test.DTOModels;
using JFS_Test.Models;
using System.Globalization;

namespace JFS_Test.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Payment, PaymentDto>();
            CreateMap<Balance, BalanceDto>()
            .ForMember(dest => dest.Period,
            opt => opt.MapFrom(
                src => DateTime.ParseExact(
                    src.Period.ToString(), "yyyyMM", CultureInfo.InvariantCulture, DateTimeStyles.None)));
        }
    }
}
