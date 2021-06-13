using EMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Repository
{
    public interface IAttendenceRepository : IGenericRepository<EmployeeAttendence>
    {
        EmployeeAttendence GetEmployeeAttendence(int empId, DateTime date);
        void DeleteAttendence(int attendenceId);
    }
}
