using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Acc.Api.Models.Entity;

public abstract class EntityBase
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    [StringLength(256)]
    public string CreatedBy { get; set; }
    public DateTime ModifiedAt { get; set; }
    [StringLength(256)]
    public string ModifiedBy { get; set; }

    public EntityBase()
    {
        CreatedAt = DateTime.UtcNow;
        ModifiedAt = DateTime.UtcNow;
        CreatedBy = "unknown";
        ModifiedBy = "unknown";
    }
}