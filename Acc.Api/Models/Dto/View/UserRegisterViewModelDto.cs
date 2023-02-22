using System.ComponentModel.DataAnnotations;

namespace Acc.Api.Models.Dto.View;

public class UserRegisterViewModelDto 
{
   [Required]
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }
    [Required]
    public string Phone { get; set; }
    [Required]
    public string Address { get; set; }
}