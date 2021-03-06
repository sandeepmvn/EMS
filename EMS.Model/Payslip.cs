using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Model
{
    public class Payslip
    {
        [Key]
        public int PKPayslipId { get; set; }
        [Required]
        public int FKEmployeeId { get; set; }
        public DateTime MonthDate { get; set; }
        public DateTime CreditedOn { get; set; }
        [Required]
        public decimal Amount { get; set; }
    }
}
