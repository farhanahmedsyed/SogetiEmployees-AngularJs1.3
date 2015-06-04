using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

using HRModel;

namespace HRDAL
{
    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            HasKey(x => x.ID);
            Property(x => x.FirstName).IsRequired();
            Property(x => x.LastName).IsRequired();
            //HasOptional(x => x.Salary).WithRequired(x => x.Employee);
            ToTable("Employee");
        }

    }
}
