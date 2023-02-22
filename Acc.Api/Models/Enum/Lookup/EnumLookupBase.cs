using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Acc.Api.Models.Enum.Lookup;

public abstract class EnumLookupBase<T> where T : System.Enum
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public T Id { get; set; }
    [Required]
    [StringLength(64)]
    public string Name { get; set; }
    [StringLength(256)]
    public string Description { get; set; }
}

public static class EnumLookupExtensionMethods
{
    public static void PopulateEnumValues<TEnum, TLookup>(this ModelBuilder modelBuilder)
        where TEnum: System.Enum where TLookup : EnumLookupBase<TEnum>, new()
    {
        modelBuilder.Entity<TLookup>()
            .Property(e => e.Id)
            .ValueGeneratedNever();

        modelBuilder.Entity<TLookup>()
            .HasData(
                System.Enum.GetValues(typeof(TEnum))
                    .Cast<TEnum>()
                    .Select(e => new TLookup
                    {
                        Id = e,
                        Name = e.ToString(),
                        Description = e.GetType()
                            .GetMember(e.ToString())
                            .First()
                            .GetCustomAttribute<DescriptionAttribute>()
                            .Description ?? string.Empty
                    })
            );
    }
}