using EMS.BO;
using EMS.Model;
using EMS.Repository;
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
        private IRoleRepository _roleRepository;
        public RoleAPIController()
        {
            this._roleRepository = new RoleRepository(new EMSContext());
        }

        //[HttpGet]
        //[Route("GetRoles")]
        //public IHttpActionResult GetRoles()
        //{
        //    return Ok(this._roleRepository.GetAll());
        //}

        //[HttpGet]
        //[Route("GetRoleById/{roleId}")]
        //public IHttpActionResult GetRoleById(int roleId)
        //{
        //    return Ok(this._roleRepository.GetById(roleId));
        //}
    }
}
