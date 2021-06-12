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
    [RoutePrefix("api/Attendence")]
    public class AttendenceController : ApiController
    {
        AttendenceBO attendenceBO = new AttendenceBO();

        [HttpGet]
        [Route("GetEmployeerByEmpId/{empId}/{date}")]
        public IHttpActionResult GetEmployeeAttendence(int empId,DateTime date)
        {
            return Ok(attendenceBO.GetEmployeeAttendence(empId,date));
        }

        [HttpPost]
        [Route("AddEmployeeAttendence")]
        public IHttpActionResult AddEmployeeAttendence(EmployeeAttendence attendence)
        {
            attendenceBO.AddEmployeeAttendence(attendence);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateEmployeeAttendence")]
        public IHttpActionResult UpdateEmployeeAttendence(EmployeeAttendence attendence)
        {
            attendenceBO.UpdateEmployeeAttendence(attendence);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteAttendence")]
        public IHttpActionResult DeleteAttendence(int attendenceId)
        {
            attendenceBO.DeleteAttendence(attendenceId);
            return Ok();
        }
    }
}
