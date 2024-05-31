using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Migrations;

internal static class Seeds
{
    public static void SeedAdminData(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Organization>().HasData(
            new Organization
            {
                Id = 1,
                Name = "Organization 1",
                SlugTenant = "org1"
            },
            new Organization
            {
                Id = 2,
                Name = "Organization 2",
                SlugTenant = "org2"
            }
        );

        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = "1",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                PasswordHash = new PasswordHasher<User>().HashPassword(null, "admin")
            }
        );

        modelBuilder.Entity<UserOrganization>().HasData(
            new UserOrganization
            {
                Id = 1,
                UserId = "1",
                OrganizationId = 1
            },
            new UserOrganization
            {
                Id = 2,
                UserId = "1",
                OrganizationId = 2
            }
        );
    }

    public static void SeedApplicationData(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "Product 1",
                Description = "Description 1",
                Price = 100
            },
            new Product
            {
                Id = 2,
                Name = "Product 2",
                Description = "Description 2",
                Price = 200
            },
            new Product
            {
                Id = 3,
                Name = "Product 3",
                Description = "Description 3",
                Price = 300
            }
        );
    }
}
