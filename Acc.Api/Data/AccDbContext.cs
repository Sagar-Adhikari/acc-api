using Acc.Api.Models.Entity;
using Acc.Api.Models.Enum;
using Acc.Api.Models.Enum.Lookup;
using Microsoft.EntityFrameworkCore;

namespace Acc.Api.Data;

public class AccDbContext : DbContext
{
    public AccDbContext(DbContextOptions<AccDbContext> options): base(options) {}
    public DbSet<Account> Accounts { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<AccountUser> AccountUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasIndex(_ => _.Email).IsUnique();
        modelBuilder.Entity<User>().HasIndex(_ => _.Phone).IsUnique();
        
        
        modelBuilder.PopulateEnumValues<UserRole,UserRoleLookup>();
    }
}

