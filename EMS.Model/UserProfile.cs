using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Model
{
    public class UserProfile
    {
        [Key]
        public int PKUserId { get; set; }
        public int FKRoleId { get; set; }
        public int EmployeeId { get; set; }

        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EmailId { get; set; }
        public string PhoneNumber { get; set; }
        public string Designation { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Workplace { get; set; }
        public bool IsActive { get; set; }

    }
}
