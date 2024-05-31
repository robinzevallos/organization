using Infrastructure.Services;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI.Middlewares;

public class TenantMiddleware(TenantService tenantService) : IMiddleware
{
    readonly string tenantTag = "tenant";

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var slugTenant = context.GetRouteValue(tenantTag) as string;

        if (!slugTenant.IsNullOrEmpty())
        {
            await tenantService.SetTenantAsync(slugTenant);
        }

        await next.Invoke(context);
    }
}