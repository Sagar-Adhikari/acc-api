namespace Acc.Api.Models.Dto;

public class UserDto : UserCreateDto
{
    public Guid Id { get; set; }
}

public class UserCreateDto
{
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
}