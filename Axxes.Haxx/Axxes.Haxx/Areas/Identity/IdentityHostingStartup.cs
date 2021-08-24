using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Axxes.Haxx.Areas.Identity.IdentityHostingStartup))]
namespace Axxes.Haxx.Areas.Identity
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