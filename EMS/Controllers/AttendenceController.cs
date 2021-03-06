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
    [RoutePrefix("api/Attendence")]
    public class AttendenceController : ApiController
    {
        //AttendenceBO attendenceBO = new AttendenceBO();

        private IAttendenceRepository _attendenceRepository;
        public AttendenceController()
        {
            this._attendenceRepository = new AttendenceRepository(new EMSContext());
        }

        //[HttpGet]
        //[Route("GetEmployeerByEmpId/{empId}/{date}")]
        //public IHttpActionResult GetEmployeeAttendence(int empId,DateTime date)
        //{
        //    return Ok(this._attendenceRepository.GetEmployeeAttendence(empId,date));
        //}

        [HttpPost]
        [Route("AddEmployeeAttendence")]
        public IHttpActionResult AddEmployeeAttendence([FromBody] AttendenceVM attendence)
        {
            if (Helper.GetEmpIdFromClaims(User as ClaimsPrincipal) != attendence.EmployeeId)
                return Unauthorized();
            this._attendenceRepository.AddAttendence(attendence);
            return Ok();
        }

        //[HttpPut]
        //[Route("UpdateEmployeeAttendence")]
        //public IHttpActionResult UpdateEmployeeAttendence([FromBody] EmployeeAttendence attendence)
        //{
        //    this._attendenceRepository.Update(attendence);
        //    return Ok();
        //}

        //[HttpDelete]
        //[Route("DeleteAttendence")]
        //public IHttpActionResult DeleteAttendence(int attendenceId)
        //{
        //    this._attendenceRepository.DeleteAttendence(attendenceId);
        //    return Ok();
        //}
    }
}
