using EMS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EMS.BO
{
    public class AttendenceBO
    {
        EMSContext context = new EMSContext();

       
        public EmployeeAttendence GetEmployeeAttendence(int empId,DateTime date)
        {
            return context.EmployeeAttendence.Where(x => x.FKEmployeeId == empId && x.AttendanceOn == date).FirstOrDefault();
        }

        public void AddEmployeeAttendence(EmployeeAttendence attendence)
        {
            context.EmployeeAttendence.Add(attendence);
            context.SaveChanges();
        }

        public void UpdateEmployeeAttendence(EmployeeAttendence attendence)
        {
            context.Entry<EmployeeAttendence>(attendence).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteAttendence(int attendenceId)
        {
            var attendence = context.EmployeeAttendence.Find(attendenceId);
            context.EmployeeAttendence.Remove(attendence);
            context.SaveChanges();
        }
    }
}