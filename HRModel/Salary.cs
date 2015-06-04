using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRModel
{
    public class Salary:Auditable
    {
        public int ID { get; set; }
        public int EmployeeId { get; set; }
        public double GrossPay { get; set; }
        public double TaxRate { get; set; }        
        public bool Four01k { get; set; }
        public int Four01kContricution { get; set; }
        public int MedicalContribution { get; set; }
        //public virtual Employee Employee { get; set; }
    }
}
