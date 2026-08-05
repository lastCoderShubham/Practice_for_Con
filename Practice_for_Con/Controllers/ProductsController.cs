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

            var result = Storage.Products.Find(x => x.Id == id);

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
            

            var product = Storage.Products.Where(x => x.Name == name).FirstOrDefault(); 

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create( Product product)
        {

            if(product.Id == null || product.Name == null)
            {
                return BadRequest();
            }

            Storage.Products.Add(product);
            return CreatedAtAction(nameof(GetById),new {id = product.Id}, product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, string name)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            Storage.Products[id -1].Name = name;
            return NoContent();
        }
    }
}
SELECT COUNT(*) FROM Employees 
SELECT SUM(Salary) as TotalSalary FROM Employees
SELECT AVG(Salary) as AverageSalary from Employees
Select MAX(Salary) as MaximumSalary from Employees
Select MIN(Salary) AS LowestSalary FROM Employees
SELECT Department, COUNT(*) FROM Employees GROUP BY Department;
SELECT Department, AVG(Salary) FROM Employees GROUP BY Department;
SELECT Department, AVG(Salary) FROM Employees GROUP BY Department HAVING AVG(Salary) > 70000
SELECT Department, COUNT(Department) FROM Employees GROUP BY Department HAVING COUNT(*) > 3
SELECT City, SUM(Salary) FROM Employees GROUP BY City
SELECT Top 1 Department, AVG(Salary) AverageSalary FROM Employees GROUP BY Department ORDER BY AVG(Salary) DESC
SELECT Top 1 City, COUNT(*) FROM Employees GROUP BY City ORDER BY COUNT(*) DESC
