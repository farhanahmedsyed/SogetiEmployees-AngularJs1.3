using HRDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBL
{
    public interface IEmployeeBL
    {
        List<EmployeeDTO> GetEmployees();
        bool SaveEmployee(EmployeeDTO employee);
        List<DesinationDTO> GetDesignations();
        bool SaveEmployeeSalary(EmployeeSalaryDTO employeeSalary);
        EmployeeSalaryDTO GetEmployeeSalary(int id);
    }
}
