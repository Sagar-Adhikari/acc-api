using System.ComponentModel.DataAnnotations;

namespace Acc.Api.Models.Entity;

public class Account : EntityBase
{
    [StringLength(256)]
    public string Name { get; set; }
}