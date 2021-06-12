using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Model
{
    public class EmployeeLeave
    {
        [Key]
        public int PKLeaveId { get; set; }
        public int FKEmployeeId { get; set; }
        public int NoOfDays { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }

       
    }
}
