using Microsoft.AspNetCore.Builder;

namespace MyCalisthenicApp.Web.Middlewares
{
    public static class SeedRolesMiddlewareExtensions
    {
        public static IApplicationBuilder UseSeedRolesMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SeedRolesMiddleware>();
        }
    }
}
