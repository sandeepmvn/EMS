using EMS.Model;
using EMS.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Repository
{
    public interface ILeaveRepository : IGenericRepository<EmployeeLeave>
    {
        List<LeaveVM> GetEmployeeLeaves();
        //List<EmployeeLeave> GetEmployeePendingLeaves();
        List<LeaveVM> GetEmployeeLeavesByEmpId(int empId);

        void AddEmployeeLeave(LeaveVM leave);
    }
}
