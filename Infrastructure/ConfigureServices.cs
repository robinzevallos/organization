using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<AdminDbContext>()
            .AddDefaultTokenProviders();

        services.AddDbContext<AdminDbContext>(options =>
        {
            options.UseSqlite(configuration.GetConnectionString("Admin"));
        });

        services.AddDbContext<ApplicationDbContext>();

        services.AddMemoryCache();

        services
            .AddScoped<TenantService>()
            .AddTransient<IdentityService>();

        return services;
    }
}
