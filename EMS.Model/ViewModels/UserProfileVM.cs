using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Model.ViewModels
{
    public class UserProfileVM
    {
        public int RoleId { get; set; }

        [Required(ErrorMessage = "Please enter employeeId.")]
        [DisplayName("Employee Id")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Please enter emailId")]
        [DisplayName("Email Id")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "Please enter first name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter Date Of Birth")]
        [DisplayName("Date of birth")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please enter Phone Number")]
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter designation")]
        public string Designation { get; set; }
        [Required(ErrorMessage = "Please enter gender")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Please enter address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter workplace")]
        public string Workplace { get; set; }
        public bool IsActive { get; set; }
    }
}
