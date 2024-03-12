using areas.Areas.Employees.Data;
using areas.Areas.Employees.Models;
using Microsoft.AspNetCore.Mvc;

namespace areas.Areas.Employees.Controllers
{
    [Area("Employees")]
    public class EmployeeController : Controller
    {
        private static readonly EmployeeModel[] Employees = new[]
        {
            new EmployeeModel { Id = 1, FirstName="Sam", LastName="Tim" , DateOfBirth =new DateOnly(1996,1,1) , Title="Mr."},
            new EmployeeModel { Id = 2,  FirstName="Jet", LastName="Katara", DateOfBirth =new DateOnly(1997,2,1), Title="Mr." },
            new EmployeeModel { Id = 3, FirstName="AAng",  LastName="Apa"  , DateOfBirth =new DateOnly(1998,6,4), Title="Mr."},
            new EmployeeModel { Id = 4, FirstName="Raj" , LastName="Sai" , DateOfBirth = new DateOnly(1999, 10, 1), Title = "Mr."},
            new EmployeeModel { Id = 5,  FirstName="Pinky", LastName="Vani" , DateOfBirth = new DateOnly(1992, 9, 5), Title = "Mrs."},
        };

        public IActionResult Index()
        {
            var empDTO = new EmployeeDTO()
            {
                Employee = new EmployeeModel(),
                Employees = Employees.ToList(),
            };
            return View(empDTO);
        }
    }
}
