using Acc.Api.Models.Dto;

namespace Acc.Api.Services.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserDto>> List();

    Task<UserDto> Create(UserCreateDto userCreateDto);

    Task Delete(Guid id);


}