using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HrAndPayrollSystem.Models
{
    public class HrAndPayroll : DbContext
    {
        static HrAndPayroll()
        {
            Database.SetInitializer<HrAndPayroll>(null);
        }
        public HrAndPayroll()   : base("name = HrAndPayroll")  { }
       
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<PaymentMode> PaymentModes { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Prvnces> Prvnces { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<HrAndPayrollSystem.Models.UserRegister> UserRegisters { get; set; }

        public System.Data.Entity.DbSet<HrAndPayrollSystem.Models.AdminLogin> AdminLogins { get; set; }
    }
}