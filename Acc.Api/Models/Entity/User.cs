using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Acc.Api.Models.Entity;

public class User : EntityBase
{
    [StringLength(256)] public string FirstName { get; set; }
    [StringLength(256)] public string MiddleName { get; set; }
    [StringLength(256)] public string LastName { get; set; }
    [StringLength(256)] public string Email { get; set; }
    [StringLength(16)] public string Phone { get; set; }
    [StringLength(512)] public string Password { get; set; }
    [StringLength(128)] public string ExternalLoginProvider { get; set; }
    [StringLength(128)] public string ExternalLoginId { get; set; }

    [NotMapped]
    public string FullName => FirstName + ' ' + MiddleName + ' ' + LastName;
}