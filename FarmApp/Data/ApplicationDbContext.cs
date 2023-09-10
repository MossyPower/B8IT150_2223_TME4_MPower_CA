using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FarmApp.Models;

namespace FarmApp.Data;

public class ApplicationDbContext : IdentityDbContext <ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    // Custom identity
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

    internal Task UpdateAsync(object description)
    {
        throw new NotImplementedException();
    }

    internal Task Find(string? description)
    {
        throw new NotImplementedException();
    }

    // Add product model to the context
    public DbSet<Product> Product { get; set; } = default!;

    // Add privacy model to the context
    public DbSet<PrivacyModel> PrivacyModel { get; set; }
}
