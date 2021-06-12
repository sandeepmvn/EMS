using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Model
{
    public class EmployeeAttendence
    {
        [Key]
        public int PKAttendanceId { get; set; }
        public int FKEmployeeId { get; set; }
        public DateTime AttendanceOn { get; set; }
        public int WorkingHours { get; set; }

    }
}
