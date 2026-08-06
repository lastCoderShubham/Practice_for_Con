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

SELECT Department, COUNT(*) FROM Employees WHERE Experience > 4 GROUP BY Department 
SELECT Department, COUNT(*) AS TotalEmployee FROM Employees WHERE Salary > 60000 group by Department Having COUNT(*) > 1 
SELECT AVG(Salary) AS AverageSalary FROM Employees Where City = 'Mumbai'
SELECT SUM(Salary) AS TotalSalary FROM Employees Where Experience BETWEEN 3 AND 6
SELECT City, MAX(Salary) AS MaxSalary FROM Employees GROUP BY City HAVING MAX(Salary) > 80000
SELECT Department, MIN(Experience) as MinExperience from Employees Group by Department HAVING MIN(Experience) > 2
SELECT COUNT(DISTINCT Department) as Departments FROM Employees
SELECT COUNT(Distinct City) FROM Employees
SELECT Department, AVG(Salary) AS AverageSalary, COUNT(*) TotalEmployee FROM Employees GROUP BY Department HAVING AVG(Salary) Between 60000 AND 75000 AND COUNT(*) > 2
SELECT City, SUM(Salary) AS TotalSalary, AVG(Experience) AS AverageExperience FROM Employees GROUP BY City HAVING SUM(Salary) > 200000 AND AVG(Experience) > 4


    using EFPractice1.Data;
using Microsoft.EntityFrameworkCore;


var options = new DbContextOptionsBuilder<CompanyDbContext>().UseSqlServer("Server = localhost\\SQLEXPRESS; Database: EFCorePrac1; Trusted_Coonection = True; TrustSerevrCertificate = True").Options;

using var context = new CompanyDbContext(options);

Console.WriteLine("DbContext Created SUccessfully");


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFPractice1.Models;
using Microsoft.EntityFrameworkCore;

namespace EFPractice1.Data
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options)
        { }
        public DbSet<Employee> Employees { get; set; }
    }
}
