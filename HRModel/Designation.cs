using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRModel
{
    public class Designation : Auditable
    {
        public int ID { get; set; }
        public string Description { get; set; }
    }
}
