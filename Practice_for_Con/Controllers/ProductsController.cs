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

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            List<Product> products = new List<Product>()
            {

                    new Product { Id = 1, Name = "Laptop" },
                    new Product { Id = 2, Name = "Mouse" }

             };

            var result = products.Find(x => x.Id == id);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(products[id - 1]);

        }

        [HttpGet("search")]
        public ActionResult<Product> Search([FromQuery] string name)
        {
            List<Product> products = new List<Product>()
            {

                    new Product { Id = 1, Name = "Laptop" },
                    new Product { Id = 2, Name = "Mouse" }

             };

            var product = products.Where(x => x.Name == name).FirstOrDefault(); 

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
    }
}
