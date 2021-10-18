using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Gerenciamento_Vendas.UI.Web.Areas.Identity.IdentityHostingStartup))]
namespace Gerenciamento_Vendas.UI.Web.Areas.Identity
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