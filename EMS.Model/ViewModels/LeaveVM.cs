using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Model.ViewModels
{
    public class LeaveVM
    {
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public int NoOfDays { get; set; }
        [Required]
        public string Reason { get; set; }
        public string Status { get; set; }
    }
}
