using EMS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Repository
{
    public class AttendenceRepository : GenericRepository<EmployeeAttendence>, IAttendenceRepository
    {
        public AttendenceRepository(DbContext db) : base(db)
        {

        }

        public EmployeeAttendence GetEmployeeAttendence(int empId, DateTime date)
        {
            return ds.Where(x => x.FKEmployeeId == empId && x.AttendanceOn == date).FirstOrDefault();
        }

        public void DeleteAttendence(int attendenceId)
        {
            var attendence = ds.Find(attendenceId);
            Update(attendence);
        }
    }
}
