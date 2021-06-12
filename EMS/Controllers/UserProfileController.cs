using EMS.BO;
using EMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMS.Controllers
{
    [RoutePrefix("api/UserProfile")]
    public class UserProfileController : ApiController
    {
        UserProfileBO userProfileBO = new UserProfileBO();

        [HttpGet]
        [Route("GetAllEmployee")]
        public IHttpActionResult GetAllEmployee()
        {
            return Ok(userProfileBO.GetAllEmployee());
        }

        [HttpGet]
        [Route("GetEmployeerByEmpId/{empId}")]
        public IHttpActionResult GetEmployeerByEmpId(int empId)
        {
            return Ok(userProfileBO.GetEmployeerByEmpId(empId));
        }

        [HttpPost]
        [Route("AddEmployee")]
        public IHttpActionResult AddEmployee(UserProfile userProfile)
        {
            userProfile.FKRoleId = 2;
            userProfileBO.AddEmployee(userProfile);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public IHttpActionResult UpdateEmployee(UserProfile userProfile)
        {
            userProfileBO.UpdateEmployee(userProfile);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteEmployee")]
        public IHttpActionResult DeleteEmployee(int empId)
        {
            userProfileBO.DeleteEmployee(empId);
            return Ok();
        }

    }
}
