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
        Storage storage = new Storage();

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            var result = storage.Products.Find(x => x.Id == id);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);

        }
        //[Route("api/products/search")]
        [HttpGet("search")]
        public ActionResult<Product> Search([FromQuery] string name)
        {
            

            var product = storage.Products.Where(x => x.Name == name).FirstOrDefault(); 

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost("{product}")]
        public IActionResult Create( Product product)
        {

            if(product.Id == null || product.Name == null)
            {
                return BadRequest();
            }

            storage.Products.Add(product);
            return CreatedAtAction(nameof(GetById),new {id = product.Id}, product);
        }
    }
}
