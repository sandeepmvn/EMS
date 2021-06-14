using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Model.ViewModels
{
    public class PayslipVM
    {
        public int PKPayslipId { get; set; }

        [Required(ErrorMessage = "Please enter employee Id.")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid employee Id")]
        [DisplayName("Employee Id")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Please select month.")]
        [DisplayName("Month Date")]
        public DateTime MonthDate { get; set; }

        [DisplayName("Credited On")]
        public DateTime CreditedOn { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}
