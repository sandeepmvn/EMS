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
        [Required]
        public int FKEmployeeId { get; set; }
        [Required]
        public int NoOfDays { get; set; }
        [Required]
        [StringLength(50)]
        public string Reason { get; set; }
        public string Status { get; set; }

       
    }
}
