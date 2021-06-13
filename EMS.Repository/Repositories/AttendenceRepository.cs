﻿using EMS.Model;
using EMS.Model.ViewModels;
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

        public AttendenceVM GetEmployeeAttendence(int empId, DateTime date)
        {
            //return ds.Where(x => x.FKEmployeeId == empId && x.AttendanceOn == date).FirstOrDefault();
            return ds.Select(x => new AttendenceVM
            {
               EmployeeId=x.FKEmployeeId,
               AttendenceOn=x.AttendanceOn,
               WorkingHours=x.WorkingHours
            }).FirstOrDefault(x => x.EmployeeId == empId && x.AttendenceOn == date);
        }

        public void AddAttendence(AttendenceVM attendenceVM)
        {
            var attendence = ds.Find(attendenceVM.EmployeeId);
            attendence.FKEmployeeId = attendenceVM.EmployeeId;
            attendence.AttendanceOn = attendenceVM.AttendenceOn;
            attendence.WorkingHours = attendenceVM.WorkingHours;
            Add(attendence);
        }

        public void DeleteAttendence(int attendenceId)
        {
            var attendence = ds.Find(attendenceId);
            Update(attendence);
        }
    }
}
