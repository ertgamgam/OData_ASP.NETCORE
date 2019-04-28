using ASP.NET_CORE_OData.Context.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET_CORE_OData.Model
{
    [ODataTable("Products")]
    public class Products
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Number { get; set; }

        public string Category { get; set; }

        [ForeignKey("Owner")]
        public  int? OwnerId { get; set; }

        public Owner Owner { get; set; }



    }
}
