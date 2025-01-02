using AutoMapper;
using Dtos.Account;
using Models;

namespace Repository.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Account, AccountDto>().ReverseMap();
            CreateMap<Account, AccountBaseDto>().ReverseMap();
            CreateMap<Account, NewBaseAccountDto>().ReverseMap();
            CreateMap<Account, NewEmployeeAccountDto>().ReverseMap();
            CreateMap<AccountDto, LoginAccountDto>();

        }
    }
}
