using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Model
{
    public class Role
    {
        [Key]
        public int PKRoleId { get; set; }
        public string RoleName { get; set; }

    }
}
