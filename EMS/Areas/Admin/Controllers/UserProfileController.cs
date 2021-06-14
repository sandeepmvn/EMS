using EMS.BO;
using EMS.Model;
using EMS.Model.ViewModels;
using EMS.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EMS.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserProfileController : Controller
    {
        private ILeaveRepository _leaveRepository;
        private IAttendenceRepository _attendenceRepository;
        private IUserProfileRepository _userProfileRepository;

        public UserProfileController()
        {
            this._userProfileRepository = new UserProfileRepository(new EMSContext());
            this._attendenceRepository = new AttendenceRepository(new EMSContext());
            this._leaveRepository = new LeaveRepository(new EMSContext());
        }
        // GET: Admin/UserProfile
        public ActionResult Index()
        {
            var obj = this._userProfileRepository.GetAllEmployee();
            return View(obj);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserProfileVM userProfile)
        {
            if (ModelState.IsValid)
            {
                var user=this._userProfileRepository.IsUserExist(userProfile.EmployeeId, userProfile.EmailId);
                if(user is null)
                {
                    this._userProfileRepository.AddUserProfile(userProfile);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Either emailId or employeeId already exist.");
                }
                
            }
            return View(userProfile);
        }

        [HttpGet]
        public ActionResult ManageEmployee()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int SearchString)
        {
            UserProfileVM userProfile = this._userProfileRepository.GetEmployeeByEmpId(SearchString);
            if (userProfile == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserProfile = userProfile;
            return View("ManageEmployee", userProfile);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ManageEmployee(UserProfileVM userProfile)
        {
            if (ModelState.IsValid)
            {
                this._userProfileRepository.UpdateUserProfile(userProfile);
                return RedirectToAction("Index");
            }
            return View(userProfile);
        }


        [HttpGet]
        public ActionResult DeleteEmployee(int empId)
        {
            this._userProfileRepository.DeleteEmployee(empId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetAttendence()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAttendenceByEmpId(int EmpId, DateTime DateOfAttendence)
        {
            //DateOfAttendence = Convert.ToDateTime(DateOfAttendence.ToString("dd/M/yyyy", CultureInfo.InvariantCulture));
            var attendence = this._attendenceRepository.GetEmployeeAttendence(EmpId, DateOfAttendence);
            if (attendence == null)
            {
                return HttpNotFound();
            }
            ViewBag.Attendence = attendence;
            return View("GetAttendence", attendence);
        }

        public ActionResult ActionOnLeave()
        {
            var obj = new List<SelectListItem>
        {
            new SelectListItem {Text="Pending", Value="Pending"},
            new SelectListItem {Text="Accepted", Value="Accepted"},
            new SelectListItem {Text="Rejected", Value="Rejected"},
        };
            ViewBag.status = obj;
            var leaves = this._leaveRepository.GetEmployeeLeaves();
            return View(leaves);
        }

        [HttpPost]
        public ActionResult StatusForLeave(int leaveId, string status)
        {
            this._leaveRepository.UpdateEmployeeLeaveStatus(leaveId,status);
            return Json("Success");
        }
    }
}