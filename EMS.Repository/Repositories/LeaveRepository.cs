using EMS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Repository
{
    public class LeaveRepository : GenericRepository<EmployeeLeave>, ILeaveRepository
    {
        public LeaveRepository(DbContext db) : base(db)
        {

        }

        public List<EmployeeLeave> GetEmployeePendingLeaves()
        {
            return ds.Where(x => x.Status == "Pending").ToList();
        }

        public List<EmployeeLeave> GetEmployeeLeavesByEmpId(int empId)
        {
            return ds.Where(x => x.FKEmployeeId == empId).ToList();
        }

    }
}
