using AutoMapper;
using JFS_Test.DTOModels;
using JFS_Test.Models;

namespace JFS_Test.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Payment, PaymentDto>();
            CreateMap<Balance, BalanceDto>()
                .ForMember(
                dest => dest.Period,
                op => op.MapFrom(
                    src => DateTime.ParseExact(src.Period.ToString(), "yyyyMM", null)));
        }
    }
}
