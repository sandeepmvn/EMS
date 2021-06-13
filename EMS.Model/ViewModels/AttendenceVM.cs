using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Model.ViewModels
{
    public class AttendenceVM
    {
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public DateTime AttendenceOn { get; set; }
        [Required]
        public int WorkingHours { get; set; }
    }
}
