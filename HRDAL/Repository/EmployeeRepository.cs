using HRModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HRDAL
{
    public class EmployeeRepository:RepositoryBase<Employee>,IEmployeeRepository
    {
        public EmployeeRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
        public List<EmployeeDTO> GetEmployees()
        {
            List<EmployeeDTO> response = new List<EmployeeDTO>();

            var db = Context;
           
            response = (from e in db.Employees
                        select new EmployeeDTO()
                        {
                            ID = e.ID,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            IsActive = e.IsActive
                            ,
                            EmployeeDetails = e.EmployeeDetails.Select(d => new EmployeeDetailDTO
                            {
                                EmployeeId = d.ID,
                                PerformanceScore = d.PerformanceScore,
                                Year = d.Year
                            }).Where(x => x.EmployeeId == e.ID).ToList()

                        }).ToList();
          
            return response;
            
        }


        public List<DesinationDTO> GetDesignations()
        {
            List<DesinationDTO> response = new List<DesinationDTO>();

            var db = Context;

            response = (from d in db.Designations
                        select new DesinationDTO()
                        {
                            ID = d.ID,
                            Designation = d.Description                            
                        }).ToList();

            return response;
        }

        public bool SaveEmployee(EmployeeDTO employee)
        {
            bool response = false;
            DateTime currentDateTime = DateTime.Now;
            var db = Context;

            var empObject = db.Employees.SingleOrDefault(x => x.ID == employee.ID);
            Employee newEmployee=null;

            if (empObject == null)
            {
                newEmployee = new Employee
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    IsActive = employee.IsActive,
                    Designation = employee.Designation,
                    UpdatedBy = employee.UpdatedBy,
                    UpdatedDateTime = currentDateTime,
                    CreatedBy = employee.UpdatedBy,
                    CreatedDateTime = currentDateTime

                };

                foreach (var item in employee.EmployeeDetails)
                {
                    var ed = new EmployeeDetail();

                    ed.EmployeeId = newEmployee.ID;
                    ed.PerformanceScore = item.PerformanceScore;
                    ed.Year = item.Year;

                    newEmployee.EmployeeDetails.Add(ed);
                }                

                Add(newEmployee);          

            }
            else
            {
                empObject.FirstName = employee.FirstName;
                empObject.LastName = employee.LastName;
                empObject.IsActive = employee.IsActive;
                empObject.UpdatedBy = employee.UpdatedBy;
                empObject.UpdatedDateTime = currentDateTime;

            };
            
            int result = db.SaveChanges();
           
            if (result > 0) response = true;
            
            return response;
        }

        public bool RemoveEmployee(EmployeeDTO employee)
        {
            return true;
        }
        
        public bool SaveEmployeeSalary(EmployeeSalaryDTO employeeSalary)
        {
            bool response = false;
            DateTime currentDateTime = DateTime.Now;           
            var db = Context;

            var salaryObject = db.Salaries.SingleOrDefault(x => x.EmployeeId == employeeSalary.EmployeeId);

            Salary newSalary = null;

            if (salaryObject == null)
            {
                newSalary = new Salary
                {
                 
                    EmployeeId = employeeSalary.EmployeeId,
                    GrossPay = employeeSalary.GrossPay,
                    Four01k = employeeSalary.Four01k,
                    Four01kContricution = employeeSalary.Four01kContricution,
                    MedicalContribution = employeeSalary.MedicalContribution,
                    TaxRate = employeeSalary.TaxRate,
                    UpdatedBy = employeeSalary.UpdatedBy,
                    UpdatedDateTime = currentDateTime,
                    CreatedBy = employeeSalary.UpdatedBy,
                    CreatedDateTime = currentDateTime

                };

                db.Salaries.Add(newSalary);
            }
            else
            {
                salaryObject.GrossPay = employeeSalary.GrossPay;
                salaryObject.Four01k = employeeSalary.Four01k;
                salaryObject.Four01kContricution = employeeSalary.Four01kContricution;
                salaryObject.MedicalContribution = employeeSalary.MedicalContribution;
                salaryObject.TaxRate = employeeSalary.TaxRate;
                salaryObject.UpdatedBy = employeeSalary.UpdatedBy;
                salaryObject.UpdatedDateTime = currentDateTime;
            };

            int result = db.SaveChanges();

            if (result > 0) response = true;

            return response;
        }


        public EmployeeSalaryDTO GetEmployeeSalary(int id)
        {
            //var response = new EmployeeSalaryDTO();

            var db = Context;

            var response = db.Salaries.Select(s =>
                                new EmployeeSalaryDTO
                                {
                                    EmployeeId = s.EmployeeId,
                                    GrossPay = s.GrossPay,
                                    Four01k=s.Four01k,
                                    Four01kContricution = s.Four01kContricution,
                                    TaxRate = s.TaxRate,
                                    MedicalContribution = s.MedicalContribution,
                                    UpdatedBy = s.UpdatedBy
                                }).Where(x => x.EmployeeId == id);

            return response.SingleOrDefault();            
            
        }
    }
}
