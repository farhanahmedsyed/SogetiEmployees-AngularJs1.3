using HRBL;
using HRDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SogetiEmployees.Controllers
{
    public class EmployeeController : ApiController
    {
        private IEmployeeBL _employeeBL;

        public EmployeeController(IEmployeeBL employeeBL)
        {
            this._employeeBL = employeeBL;
        }

        [HttpGet]
        public List<EmployeeDTO> GetEmployees()
        {
            return _employeeBL.GetEmployees();
        }
        
        [HttpPost]
        public bool SaveEmployee(EmployeeDTO employee)
        {
            return _employeeBL.SaveEmployee(employee);
        }

        [HttpGet]
        public List<DesinationDTO> GetDesignations()
        {
            return _employeeBL.GetDesignations();
        }

        [HttpPost]
        public bool SaveEmployeeSalary(EmployeeSalaryDTO employeeSalary)
        {
            return _employeeBL.SaveEmployeeSalary(employeeSalary);
        }

        [HttpGet]
        public EmployeeSalaryDTO GetEmployeeSalary(int id)
        {
            return _employeeBL.GetEmployeeSalary(id);
        }

    }
}
