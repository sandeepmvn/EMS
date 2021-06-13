using EMS.Model;
using EMS.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Repository
{
    public interface IAttendenceRepository : IGenericRepository<EmployeeAttendence>
    {
        AttendenceVM GetEmployeeAttendence(int empId, DateTime date);

        void AddAttendence(AttendenceVM attendence);
        void DeleteAttendence(int attendenceId);
    }
}
