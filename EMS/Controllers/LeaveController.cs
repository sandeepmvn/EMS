using EMS.BO;
using EMS.CustomFilters;
using EMS.Model;
using EMS.Model.Utility;
using EMS.Model.ViewModels;
using EMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EMS.Controllers
{
    [JWTAuthorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Leave")]
    public class LeaveController : ApiController
    {
        private ILeaveRepository _leaveRepository;
        public LeaveController()
        {
            this._leaveRepository = new LeaveRepository(new EMSContext());
        }

        //[HttpGet]
        //[Route("GetEmployeePendingLeaves")]
        //public IHttpActionResult GetEmployeePendingLeaves()
        //{
        //    return Ok(this._leaveRepository.GetEmployeePendingLeaves());
        //}

        [HttpGet]
        [Route("GetEmployeeLeavesByEmpId/{empId}")]
        public IHttpActionResult GetEmployeeLeavesByEmpId(int empId)
        {
            if (Helper.GetEmpIdFromClaims(User as ClaimsPrincipal) != empId)
                return Unauthorized();
            return Ok(this._leaveRepository.GetEmployeeLeavesByEmpId(empId));
        }

        [HttpPost]
        [Route("AddEmployeeLeave")]
        public IHttpActionResult AddEmployeeLeave([FromBody]LeaveVM leave)
        {
            if (Helper.GetEmpIdFromClaims(User as ClaimsPrincipal) != leave.EmployeeId)
                return Unauthorized();
            this._leaveRepository.AddEmployeeLeave(leave);
            return Ok();
        }

        //[HttpPut]
        //[Route("UpdateEmployeeLeave")]
        //public IHttpActionResult UpdateEmployeeLeave(EmployeeLeave leave)
        //{
        //    this._leaveRepository.Update(leave);
        //    return Ok();
        //}

        //[HttpDelete]
        //[Route("DeleteLeave")]
        //public IHttpActionResult DeleteLeave(int leaveId)
        //{
        //    this._leaveRepository.Delete(leaveId);
        //    return Ok();
        //}
    }
}
