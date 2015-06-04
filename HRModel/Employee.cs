using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRModel
{
    public class Employee:Auditable
    {
        public Employee()
        {
            this.EmployeeDetails = new HashSet<EmployeeDetail>();
        }
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        public string Designation { get; set; }
        public bool IsActive { get; set; }        
        public virtual ICollection<EmployeeDetail> EmployeeDetails{get;set;}
        //public virtual Salary Salary { get; set; }

    }
}
