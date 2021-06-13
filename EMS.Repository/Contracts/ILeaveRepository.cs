using EMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Repository
{
    public interface ILeaveRepository : IGenericRepository<EmployeeLeave>
    {
        List<EmployeeLeave> GetEmployeePendingLeaves();
        List<EmployeeLeave> GetEmployeeLeavesByEmpId(int empId);
    }
}
