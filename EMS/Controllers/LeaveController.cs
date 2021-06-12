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
    [RoutePrefix("api/Leave")]
    public class LeaveController : ApiController
    {
        LeaveBO leaveBO = new LeaveBO();

        [HttpGet]
        [Route("GetEmployeePendingLeaves")]
        public IHttpActionResult GetEmployeePendingLeaves()
        {
            return Ok(leaveBO.GetEmployeePendingLeaves());
        }

        [HttpGet]
        [Route("GetEmployeeLeavesByEmpId/{empId}")]
        public IHttpActionResult GetEmployeeLeavesByEmpId(int empId)
        {
            return Ok(leaveBO.GetEmployeeLeavesByEmpId(empId));
        }

        [HttpPost]
        [Route("AddEmployeeLeave")]
        public IHttpActionResult AddEmployeeLeave(EmployeeLeave leave)
        {
            leaveBO.AddEmployeeLeave(leave);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateEmployeeLeave")]
        public IHttpActionResult UpdateEmployeeLeave(EmployeeLeave leave)
        {
            leaveBO.UpdateEmployeeLeave(leave);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteLeave")]
        public IHttpActionResult DeleteLeave(int leaveId)
        {
            leaveBO.DeleteLeave(leaveId);
            return Ok();
        }
    }
}
