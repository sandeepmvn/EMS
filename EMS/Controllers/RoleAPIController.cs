using EMS.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMS.Controllers
{
    [RoutePrefix("api/RoleAPI")]
    public class RoleAPIController : ApiController
    {
        RoleBO roleBO = new RoleBO();

        [HttpGet]
        [Route("GetRoles")]
        public IHttpActionResult GetRoles()
        {
            return Ok(roleBO.GetRoles());
        }

        [HttpGet]
        [Route("GetRoleById/{roleId}")]
        public IHttpActionResult GetRoleById(int roleId)
        {
            return Ok(roleBO.GetRoleById(roleId));
        }
    }
}
