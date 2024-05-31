using Domain.Entities;
using Infrastructure.Migrations;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class ApplicationDbContext : DbContext
{
    private readonly TenantService tenantService;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, TenantService tenantService) : base(options)
    {
        this.tenantService = tenantService;

        Database.EnsureCreated();
    }

    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlite(tenantService.ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.SeedApplicationData();
    }
}
