using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Model.PartialClass
{
    public class UserModel
    {
        [Required(ErrorMessage = "Please enter emailId")]
        public string EmailId { get; set; }
        [Required(ErrorMessage = "Please enter Password")]
        public string Password { get; set; }
        public bool IsValid { get; set; }
        public UserProfile UserProfile { get; set; }
        public string RoleName { get; set; }
    }
}
