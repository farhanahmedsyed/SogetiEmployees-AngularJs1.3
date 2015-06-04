using HRModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRDAL
{
    public class EmployeeDTO
    {
        public EmployeeDTO()
        {
            this.EmployeeDetails = new List<EmployeeDetailDTO>();
        }
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool  IsActive { get; set; }
        public string Designation { get; set; }
        public string UpdatedBy { get; set; }
        public List<string> DesignationList { get; set; }
        public List<EmployeeDetailDTO> EmployeeDetails { get; set; }

    }
}
