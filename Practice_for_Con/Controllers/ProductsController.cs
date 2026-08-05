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
SELECT City, COUNT(*) FROM Employees GROUP BY City
SELECT City, COUNT(*) FROM Employees GROUP BY City HAVING COUNT(*) > 3
SELECT Department, AVG(Experience) as AverageExperience FROM Employees GROUP BY Department 
SELECT Department, AVG(Experience) as AverageExperience FROM Employees GROUP BY Department HAVING AVG(Experience) > 5
SELECT City, MAX(Salary) as MaxSalary FROM Employees GROUP BY City
SELECT Department, MIN(Salary) as MinSalary FROM Employees GROUP BY Department
SELECT Department, SUM(Salary) as TotalSalary FROM Employees GROUP BY Department HAVING SUM(SALARY) > 200000
SELECT City, AVG(Salary) as AverageSalary FROM Employees GROUP BY City HAVING AVG(Salary) > 65000
SELECT COUNT(*) as TotalEmployees FROM Employees WHERE City = 'Mumbai'
Select SUM(Salary) TotalSalary FROM Employees WHERE Department = 'IT'
SELECT Top 1 City, AVG(Salary) as AverageSalary FROM Employees GROUP BY City Order BY AVG(Salary) desc
SELECT Top 1 Department, COUNT(*) AS TotalEmployees FROM Employees GROUP BY Department ORDER BY COUNT(*) DESC
