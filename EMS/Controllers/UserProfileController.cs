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
    [RoutePrefix("api/UserProfile")]
    public class UserProfileController : ApiController
    {
        private IUserProfileRepository _userProfileRepository;
        public UserProfileController()
        {
            this._userProfileRepository = new UserProfileRepository(new EMSContext());
        }

        [HttpGet]
        [Route("GetEmployeerByEmpId/{empId}")]
        public IHttpActionResult GetEmployeerByEmpId(int empId)
        {
            if (Helper.GetEmpIdFromClaims(User as ClaimsPrincipal) != empId)
                return Unauthorized();
            return Ok(this._userProfileRepository.GetEmployeeForAPI(empId));
        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public IHttpActionResult UpdateEmployee(EmployeeRequestVM employeeRequestVM)
        {
            if (Helper.GetEmpIdFromClaims(User as ClaimsPrincipal) != employeeRequestVM.EmployeeId)
                return Unauthorized();
            this._userProfileRepository.UpdateEmployee(employeeRequestVM);
            //userProfileBO.UpdateEmployee(userProfile);
            return Ok(employeeRequestVM.EmployeeId);
        }

        //[HttpDelete]
        //[Route("DeleteEmployee")]
        //public IHttpActionResult DeleteEmployee(int empId)
        //{
        //    this._userProfileRepository.DeleteEmployee(empId);
        //    return Ok();
        //}

    }
}
