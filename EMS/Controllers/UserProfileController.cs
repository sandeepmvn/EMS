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
    [RoutePrefix("api/UserProfile")]
    public class UserProfileController : ApiController
    {
        //UserProfileBO userProfileBO = new UserProfileBO();
        private IUserProfileRepository _userProfileRepository;
        public UserProfileController()
        {
            this._userProfileRepository = new UserProfileRepository(new EMSContext());
        }

        [HttpGet]
        [Route("GetAllEmployee")]
        public IHttpActionResult GetAllEmployee()
        {
            return Ok(this._userProfileRepository.GetAllEmployee());
        }

        [HttpGet]
        [Route("GetEmployeerByEmpId/{empId}")]
        public IHttpActionResult GetEmployeerByEmpId(int empId)
        {
            return Ok(this._userProfileRepository.GetEmployeerByEmpId(empId));
        }

        [HttpPost]
        [Route("AddEmployee")]
        public IHttpActionResult AddEmployee(UserProfile userProfile)
        {
            userProfile.FKRoleId = 2;
            this._userProfileRepository.Add(userProfile);
            //userProfileBO.AddEmployee(userProfile);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public IHttpActionResult UpdateEmployee(UserProfile userProfile)
        {
            this._userProfileRepository.Update(userProfile);
            //userProfileBO.UpdateEmployee(userProfile);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteEmployee")]
        public IHttpActionResult DeleteEmployee(int empId)
        {
            this._userProfileRepository.DeleteEmployee(empId);
            return Ok();
        }

    }
}
