using ASP.NET_CORE_OData.Context.Annotations;
using System.Collections.Generic;

namespace ASP.NET_CORE_OData.Model
{
    [ODataTable("Owner")]
    public class Owner
    {
        public int Id { get; set; }
        public string  Name{ get; set; }
        public string Surname { get; set; }

        public List<Products> Products { get; set; }
    }
}
