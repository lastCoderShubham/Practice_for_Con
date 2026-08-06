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
CREATE TABLE Employees
(
EmpID INT PRIMARY KEY,
EmpName VARCHAR(50),
Department VARCHAR(30),
City VARCHAR(30),
Salary INT,
Experience INT
);

INSERT INTO Employees
VALUES
(101,'Amit','IT','Mumbai',50000,2),
(102,'Neha','HR','Delhi',60000,4),
(103,'Ravi','IT','Mumbai',70000,6),
(104,'Priya','Finance','Pune',80000,8),
(105,'Karan','HR','Delhi',55000,3),
(106,'Rohan','Sales','Bangalore',65000,5),
(107,'Sneha','IT','Pune',75000,7),
(108,'Vikas','Finance','Mumbai',90000,10),
(109,'Pooja','Sales','Delhi',62000,4),
(110,'Rahul','IT','Bangalore',58000,3),
(111,'Ankit','HR','Pune',53000,2),
(112,'Meera','Finance','Delhi',85000,9),
(113,'Kunal','Sales','Mumbai',67000,5),
(114,'Simran','IT','Pune',72000,6),
(115,'Arjun','HR','Mumbai',61000,4);

Select Department, AVG(Salary) AS AverageSalary from Employees group by Department Having AVG(Salary) between 60000 AND 80000
Select City, SUM(Salary) AS TotalSalary, COUNT(*) AS TotalEmployees from Employees Group by City HAVING SUM(Salary) > 200000 AND COUNT(*) > 2
Select Department, COUNT(*) AS TotalEmployees from Employees Where Salary > 60000 Group By Department 
Select City, AVG(Salary) As AverageSalary from Employees Where Experience > 4 Group By City
Select Department, MIN(Salary) As MinSalary from Employees where Salary > 55000 group BY Department 
Select Department, Max(Salary) As MaxSalary from Employees where Salary < 80000 group BY Department 
Select Department, SUM(Salary) AS TotalSalary from Employees Group By Department order by SUM(Salary)
Select City, COUNT(*) AS TotalEmployees from Employees Group By City Having COUNT(*) > 3
Select Distinct Department from Employees Where Department LIKE '%i%' or Department LIKE '%i' or Department LIKE 'i%'
