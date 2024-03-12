using areas.Areas.Employees.Models;

namespace areas.Areas.Employees.Data
{
    public class EmployeeDTO
    {
        public EmployeeModel Employee { get; set; }
        public List<EmployeeModel> Employees { get; set; }
    }
}
