using ASP.NET_CORE_OData.Context;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
//https://devblogs.microsoft.com/odata/supercharging-asp-net-core-api-with-odata/
namespace ASP.NET_CORE_OData
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().MigrateDbContext<ODataDBContext>((x,y)=> { }).Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
