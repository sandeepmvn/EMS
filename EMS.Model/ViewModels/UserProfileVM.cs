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

        [Required(ErrorMessage = "Please enter employee Id.")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid employee Id")]
        [DisplayName("Employee Id")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Please enter emailId")]
        [DisplayName("Email Id")]
        [StringLength(50)]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "Please enter first name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter Date Of Birth")]
        [DisplayName("Date of birth")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please enter Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter designation")]
        [StringLength(50)]
        public string Designation { get; set; }
        [Required(ErrorMessage = "Please enter gender")]
        [StringLength(10)]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Please enter address")]
        [StringLength(500)]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter workplace")]
        [StringLength(50)]
        public string Workplace { get; set; }
        public bool IsActive { get; set; }
    }
}
