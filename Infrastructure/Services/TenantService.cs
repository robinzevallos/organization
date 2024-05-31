using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services;

public class TenantService(AdminDbContext context, IMemoryCache cache, IConfiguration configuration)
{
    public string SlugTenant { get; private set; }

    public string ConnectionString { get; private set; }

    public async Task SetTenantAsync(string slugTenant)
    {
        var cacheKey = $"Cache_{slugTenant}";
        var company = cache.Get<Organization>(cacheKey);

        if (company is null)
        {
            company = await context.Organizations.FirstOrDefaultAsync(x => x.SlugTenant == slugTenant) ?? throw new Exception($"slugTenant no es válido");

            cache.Set(cacheKey, company);
        }

        SlugTenant = company.SlugTenant;

        ConnectionString = configuration.GetConnectionString("Application")!
            .Replace("{tenant}", SlugTenant);
    }
}
