using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Model
{
    public class EMSContext: DbContext
    {
        public EMSContext() : base("emsconnection")
        {
        }

        public DbSet<Role> Role { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<EmployeeAttendence> EmployeeAttendence { get; set; }
        public DbSet<EmployeeLeave> EmployeeLeave { get; set; }
        public DbSet<Payslip> Payslip { get; set; }
    }
}
