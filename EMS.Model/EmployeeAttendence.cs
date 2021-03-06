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
        [Required]
        public int FKEmployeeId { get; set; }
        [Required]
        public DateTime AttendanceOn { get; set; }
        [Required]
        public int WorkingHours { get; set; }

    }
}
