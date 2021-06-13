﻿using EMS.BO;
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
    [RoutePrefix("api/Leave")]
    public class LeaveController : ApiController
    {
        //LeaveBO leaveBO = new LeaveBO();

        private ILeaveRepository _leaveRepository;
        public LeaveController()
        {
            this._leaveRepository = new LeaveRepository(new EMSContext());
        }

        [HttpGet]
        [Route("GetEmployeePendingLeaves")]
        public IHttpActionResult GetEmployeePendingLeaves()
        {
            return Ok(this._leaveRepository.GetEmployeePendingLeaves());
        }

        [HttpGet]
        [Route("GetEmployeeLeavesByEmpId/{empId}")]
        public IHttpActionResult GetEmployeeLeavesByEmpId(int empId)
        {
            return Ok(this._leaveRepository.GetEmployeeLeavesByEmpId(empId));
        }

        [HttpPost]
        [Route("AddEmployeeLeave")]
        public IHttpActionResult AddEmployeeLeave(EmployeeLeave leave)
        {
            this._leaveRepository.Add(leave);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateEmployeeLeave")]
        public IHttpActionResult UpdateEmployeeLeave(EmployeeLeave leave)
        {
            this._leaveRepository.Update(leave);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteLeave")]
        public IHttpActionResult DeleteLeave(int leaveId)
        {
            this._leaveRepository.Delete(leaveId);
            return Ok();
        }
    }
}
