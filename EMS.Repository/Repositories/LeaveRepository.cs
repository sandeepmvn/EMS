using EMS.Model;
using EMS.Model.ViewModels;
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

        //public List<EmployeeLeave> GetEmployeePendingLeaves()
        //{
        //    return ds.Where(x => x.Status == "Pending").ToList();
        //}

        public List<LeaveVM> GetEmployeeLeaves()
        {
            return ds.Select(x => new LeaveVM()
            {
                PKLeaveId=x.PKLeaveId,
                EmployeeId = x.FKEmployeeId,
                NoOfDays = x.NoOfDays,
                Reason = x.Reason,
                Status = x.Status
            }).ToList();
        }

        public List<LeaveVM> GetEmployeeLeavesByEmpId(int empId)
        {
            return ds.Select(x=>new LeaveVM() { 
                PKLeaveId=x.PKLeaveId,
                EmployeeId=x.FKEmployeeId,
                NoOfDays=x.NoOfDays,
                Reason=x.Reason,
                Status=x.Status
            }).Where(x => x.EmployeeId == empId).ToList();
        }

        public void AddEmployeeLeave(LeaveVM leaveVM)
        {
            var leave = new EmployeeLeave();
            leave.FKEmployeeId = leaveVM.EmployeeId;
            leave.NoOfDays = leaveVM.NoOfDays;
            leave.Reason = leaveVM.Reason;
            leave.Status = "Pending";
            Add(leave);
        }

        public void UpdateEmployeeLeaveStatus(int leaveId, string status)
        {
            var leave = ds.Find(leaveId);
            leave.Status = status;
            Update(leave);
        }
    }
}
