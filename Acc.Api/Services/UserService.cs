using Acc.Api.Models.Dto;
using Acc.Api.Models.Entity;
using Acc.Api.Repositories.Interfaces;
using Acc.Api.Services.Interfaces;
using AutoMapper;

namespace Acc.Api.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<UserDto>> List()
    {
        var users = await _repository.List();
        var allUsers = _mapper.Map<List<UserDto>>(users);
        return allUsers.ToList();
    }
    public async Task<UserDto> Create(UserCreateDto userCreateDto)
    {
        var createUser = _mapper.Map<User>(userCreateDto);
        var user = await _repository.Create(createUser);
        return _mapper.Map<UserDto>(user);
    }
    public async Task Delete(Guid id)
    {
        await _repository.Delete(id);
    }
}