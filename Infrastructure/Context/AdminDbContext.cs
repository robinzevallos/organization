using Domain.Entities;
using Infrastructure.Migrations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class AdminDbContext : IdentityDbContext<User>
{
    public DbSet<Organization> Organizations { get; set; }

    public DbSet<UserOrganization> UserOrganizations { get; set; }

    public AdminDbContext(DbContextOptions<AdminDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.SeedAdminData();
    }
}