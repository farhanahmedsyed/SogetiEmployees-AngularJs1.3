using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRDAL
{
    public class EmployeeSalaryDTO
    {
        public int EmployeeId { get; set; }
        public double GrossPay { get; set; }
        public bool Four01k { get; set; }
        public int Four01kContricution { get; set; }
        public int MedicalContribution { get; set; }     
        public double TaxRate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
