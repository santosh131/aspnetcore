using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using modelbinding.Models;

namespace modelbinding.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private static readonly EmployeeModel[] Employees = new[]
        {
            new EmployeeModel { Id = 1, FirstName="Sam", LastName="Tim" , DateOfBirth =new DateOnly(1996,1,1) , Title="Mr."},
            new EmployeeModel { Id = 2,  FirstName="Jet", LastName="Katara", DateOfBirth =new DateOnly(1997,2,1), Title="Mr." },
            new EmployeeModel { Id = 3, FirstName="AAng",  LastName="Apa"  , DateOfBirth =new DateOnly(1998,6,4), Title="Mr."},
            new EmployeeModel { Id = 4, FirstName="Raj" , LastName="Sai" , DateOfBirth = new DateOnly(1999, 10, 1), Title = "Mr."},
            new EmployeeModel { Id = 5,  FirstName="Pinky", LastName="Vani" , DateOfBirth = new DateOnly(1992, 9, 5), Title = "Mrs."},
        };

        [HttpGet("GetEmployees")]
        public IEnumerable<EmployeeModel> GetEmployees()
        {
            return Employees.ToList();
        }

        [HttpGet("GetEmployee/{id}")]
        public  EmployeeModel GetEmployee(int id)
        {
            return Employees.Where(e=>e.Id==id).FirstOrDefault();
        }

        [HttpGet("GetEmployeeQS")]
        public EmployeeModel GetEmployeeQS([FromQuery]int id)
        {
            return Employees.Where(e => e.Id == id).FirstOrDefault();
        }

        [HttpGet("GetEmployeeQSConplex")]
        public EmployeeModel GetEmployeeQSConplex([FromQuery] EmployeeModel employee)
        {
            return Employees.Where(e => e.Id == employee.Id).FirstOrDefault();
        }

        [HttpPost("InsertEmployee")]
        public ActionResult InsertEmployee([FromBody]EmployeeModel employeeModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
