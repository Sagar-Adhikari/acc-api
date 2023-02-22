using Acc.Api.Models.Dto;
using Acc.Api.Models.Dto.View;
using Acc.Api.Models.Entity;
using AutoMapper;

namespace Acc.Api.MapperProfiles;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<User, UserCreateDto>().ReverseMap();
        CreateMap<User, UserDto>();
        CreateMap<User,UserRegisterViewModelDto>().ReverseMap();

        CreateMap<Account, AccountCreateDto>().ReverseMap();
        CreateMap<Account, AccountDto>();

        CreateMap<Account, AccountRegisterDto>().ReverseMap();

        CreateMap<AccountUser, AccountUserDto>();
    }
}