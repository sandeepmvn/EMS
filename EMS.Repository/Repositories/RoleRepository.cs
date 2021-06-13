using EMS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace EMS.Repository
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(DbContext db) : base(db)
        {

        }
    }
}
