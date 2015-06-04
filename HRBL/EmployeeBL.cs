using HRDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBL
{
    public class EmployeeBL:IEmployeeBL
    {
        private IEmployeeRepository _employeeRepository;
        public EmployeeBL(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }
        public List<EmployeeDTO> GetEmployees()
        {
            return _employeeRepository.GetEmployees();
        }

        public bool SaveEmployee(EmployeeDTO employee)
        {
           return _employeeRepository.SaveEmployee(employee);
        }


        public List<DesinationDTO> GetDesignations()
        {
            return _employeeRepository.GetDesignations();
        }


        public bool SaveEmployeeSalary(EmployeeSalaryDTO employeeSalary)
        {
            return _employeeRepository.SaveEmployeeSalary(employeeSalary);
        }


        public EmployeeSalaryDTO GetEmployeeSalary(int id)
        {
            return _employeeRepository.GetEmployeeSalary(id);
        }
    }
}
