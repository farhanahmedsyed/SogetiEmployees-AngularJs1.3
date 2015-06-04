using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

using HRModel;

namespace HRDAL
{
    public class DesignationsConfiguration : EntityTypeConfiguration<Designation>
    {
        public DesignationsConfiguration()
        {
            HasKey(x => x.ID);
            ToTable("Designation");
        }
    }
}
