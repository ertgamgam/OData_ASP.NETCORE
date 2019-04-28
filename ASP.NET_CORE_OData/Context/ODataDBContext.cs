using ASP.NET_CORE_OData.Model;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_CORE_OData.Context
{
    public class ODataDBContext:DbContext
    {
        public ODataDBContext(DbContextOptions<ODataDBContext> options):base(options)
        {
        }

        public DbSet<Products> Products { get; set; }
        public DbSet<Owner> Owner { get; set; }
    }
}
