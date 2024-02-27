using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using routing.Models;

namespace routing.Controllers
{
    public class EmployeeController : MyBaseController
    {
        private static readonly EmployeeModel[] Employees = new[]
      {
            new EmployeeModel { Id = 1, FirstName="Sam", LastName="Tim"  },
            new EmployeeModel { Id = 2,  FirstName="Jet", LastName="Katara" },
            new EmployeeModel { Id = 3, FirstName="AAng",  LastName="Apa"  },
            new EmployeeModel { Id = 4, FirstName="Raj" , LastName="Sai" },
            new EmployeeModel { Id = 5,  FirstName="Pinky", LastName="Vani" },
        };

        [HttpGet]
        public  IEnumerable<EmployeeModel> Get()
        {
            return Employees;
        }

        [HttpGet("{id}", Name ="GetEmployee")]
        public EmployeeModel GetEmployee(int id)
        {
            return Employees.FirstOrDefault(e => e.Id == id) ;
        }
    }
}
