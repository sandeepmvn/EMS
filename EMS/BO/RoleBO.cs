using EMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMS.BO
{
    public class RoleBO
    {
        EMSContext context = new EMSContext();

        public List<Role> GetRoles()
        {
            //DateTime currentDate = DateTime.Now.AddDays(-3);
            return context.Role.ToList();
        }

        public Role GetRoleById(int id)
        {
            return context.Role.Where(x => x.PKRoleId == id).FirstOrDefault();
        }
    }
}