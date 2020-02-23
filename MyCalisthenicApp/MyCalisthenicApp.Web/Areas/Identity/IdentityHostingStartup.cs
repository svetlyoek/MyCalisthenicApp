using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(MyCalisthenicApp.Web.Areas.Identity.IdentityHostingStartup))]
namespace MyCalisthenicApp.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}