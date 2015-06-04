using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using HRModel;


namespace HRDAL
{
    public class SogetiEmployeesDBContext : DbContext, IUnitOfWork
    {
        public SogetiEmployeesDBContext()
            : base("name=SogetiEmployeesContext")    //Code First with explicit connect string in app/web.config 
        {
            //((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 300;
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new EmployeeDetailConfiguration());
            modelBuilder.Configurations.Add(new SalaryConfiguration());
            modelBuilder.Configurations.Add(new DesignationsConfiguration());
        }

        void IUnitOfWork.SaveChanges()
        {
            base.SaveChanges();
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeDetail> EmployeeDetails { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Designation> Designations { get; set; }

    }
}
