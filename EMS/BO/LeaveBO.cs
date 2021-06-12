using EMS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EMS.BO
{
    public class LeaveBO
    {
        EMSContext context = new EMSContext();
        public List<EmployeeLeave> GetEmployeePendingLeaves()
        {
            return context.EmployeeLeave.Where(x => x.Status == "Pending").ToList();
        }

        public List<EmployeeLeave> GetEmployeeLeavesByEmpId(int empId)
        {
            return context.EmployeeLeave.Where(x => x.FKEmployeeId == empId).ToList();
        }

        public EmployeeLeave GetEmployeeLeaveByLeaveId(int leaveId)
        {
            return context.EmployeeLeave.Where(x => x.PKLeaveId == leaveId).FirstOrDefault();
        }

        public void AddEmployeeLeave(EmployeeLeave leave)
        {
            context.EmployeeLeave.Add(leave);
            context.SaveChanges();
        }

        public void UpdateEmployeeLeave(EmployeeLeave leave)
        {
            context.Entry<EmployeeLeave>(leave).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteLeave(int leaveId)
        {
            var attendence = context.EmployeeLeave.Find(leaveId);
            context.EmployeeLeave.Remove(attendence);
            context.SaveChanges();
        }
    }
}