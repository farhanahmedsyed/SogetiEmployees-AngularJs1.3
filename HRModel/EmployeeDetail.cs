using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRModel
{
    public class EmployeeDetail:Auditable
    {
        public int ID { get; set; }
        public int EmployeeId { get; set; }
        public int Year { get; set; }
        public int PerformanceScore { get; set; }
        public virtual Employee Employee{get;set;}
    }
}
