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
        [Required]
        public int FKRoleId { get; set; }
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Required]
        [StringLength(50)]
        public string EmailId { get; set; }
        [Required]
        [StringLength(15)]
        public string PhoneNumber { get; set; }
        [StringLength(50)]
        public string Designation { get; set; }
        [StringLength(10)]
        public string Gender { get; set; }
        [StringLength(500)]
        public string Address { get; set; }
        [StringLength(50)]
        public string Workplace { get; set; }
        [Required]
        public bool IsActive { get; set; }

    }
}
