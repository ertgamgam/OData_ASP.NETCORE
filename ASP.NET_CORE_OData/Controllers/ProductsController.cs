using System.Collections.Generic;
using System.Linq;
using ASP.NET_CORE_OData.Context;
using ASP.NET_CORE_OData.Model;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_CORE_OData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ODataDBContext DBContext { get; set; }
        public ProductsController(ODataDBContext dBContext)
        {
            this.DBContext = dBContext;
            if (this.DBContext.Products.Count() == 0)
            {
                List<Products> products = new List<Products>()
                {
                    (new Products(){Name="Asus",Category="Computer",Number=10 }),
                    (new Products(){Name="Toshiba",Category="Computer",Number=13 }),
                    (new Products(){Name="Samsung",Category="Phone",Number=5 }),
                    (new Products(){Name="Apple",Category="Phone",Number=8 }),
                };

                this.DBContext.Products.AddRange(products);
                this.DBContext.SaveChanges();

                Owner owner = new Owner() { Name = "Dave", Surname = "Mustaine" };
                this.DBContext.Owner.Add(owner);

                Products product = new Products() { Name = "Fender", Category = "Guitar", Number = 3 };
                this.DBContext.Products.Add(product);
                this.DBContext.SaveChanges();

                var ownerFromDB = this.DBContext.Owner.Include(s => s.Products).FirstOrDefault(o => o.Name == "Dave");
                ownerFromDB.Products.Add(product);

                this.DBContext.SaveChanges();

            }

        }


        /// <summary>
        /// test of power of OData :)
        /// (http://localhost:53798/api/products?$select=name)
        /// (http://localhost:53798/api/products?$select=ID,Name)
        /// (http://localhost:53798/api/products?$orderby=number desc)
        /// (http://localhost:53798/api/products?$orderby=number)
        /// (http://localhost:53798/api/products?$filter=number gt 10)
        /// (http://localhost:53798/api/products?$filter=category eq 'Computer')
        /// (http://localhost:53798/api/products?$expand=Owner)
        /// (http://localhost:53798/api/products?$filter=number ge 3 and number le 10)
        /// (http://localhost:53798/api/products?$filter=number gt 3 and number lt 10)
        /// </summary>
        /// <returns></returns>
        [EnableQuery]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.DBContext.Products);
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
