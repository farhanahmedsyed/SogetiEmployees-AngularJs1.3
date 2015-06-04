using HRModel;

using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRDAL
{
    public class EmployeeDetailConfiguration:EntityTypeConfiguration<EmployeeDetail>
    {
        public EmployeeDetailConfiguration()
        {
            HasKey(x => x.ID);
            Property(x => x.EmployeeId).IsRequired();
            HasRequired(x => x.Employee).WithMany(x => x.EmployeeDetails).HasForeignKey(x => x.EmployeeId);
            ToTable("EmployeeDetail");
        }
    }
}
