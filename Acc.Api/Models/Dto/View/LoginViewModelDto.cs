using System.ComponentModel.DataAnnotations;

namespace Acc.Api.Models.Dto.View;

public class LoginViewModelDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    public string Password { get; set; }
}