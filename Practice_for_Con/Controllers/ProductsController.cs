using System.Collections.Immutable;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using Practice_for_Con.Models;

namespace Practice_for_Con.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            List<Product> products = new List<Product>()
            {

                    new Product { Id = 1, Name = "Laptop" },
                    new Product { Id = 2, Name = "Mouse" }

             };
            List<int> ids = new List<int>();
            foreach(var item in products)
            {
                ids.Add(item.Id);
            }

            if(!ids.Contains(id))
            {
                return BadRequest();
            }
            return Ok(products[id -1]);
            
        }
    }
}
