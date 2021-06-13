using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Model.ViewModels
{
    public class PayslipVM
    {
        [Required]
        public int EmployeeId { get; set; }
        public DateTime MonthDate { get; set; }
        public DateTime CreditedOn { get; set; }
        [Required]
        public decimal Amount { get; set; }
    }
}
