using EMS.BO;
using EMS.Model;
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
        //UserProfileBO userProfileBO = new UserProfileBO();
        //AttendenceBO attendenceBO = new AttendenceBO();
        //LeaveBO leaveBO = new LeaveBO();

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
        public ActionResult Create(UserProfile userProfile)
        {
            if (ModelState.IsValid)
            {
                userProfile.FKRoleId = 2;
                this._userProfileRepository.Add(userProfile);
                return RedirectToAction("Index");
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

            UserProfile userProfile = this._userProfileRepository.GetEmployeerByEmpId(SearchString);
            if (userProfile == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserProfile = userProfile;
            return View("ManageEmployee", userProfile);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ManageEmployee(UserProfile userProfile)
        {
            if (ModelState.IsValid)
            {
                this._userProfileRepository.Update(userProfile);
                return RedirectToAction("Index");
            }
            return View(userProfile);
        }

        [HttpGet]
        public ActionResult GetAttendence()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAttendenceByEmpId(int EmpId, DateTime DateOfAttendence)
        {
            DateOfAttendence = Convert.ToDateTime(DateOfAttendence.ToString("dd/M/yyyy", CultureInfo.InvariantCulture));
            var attendence = this._attendenceRepository.GetEmployeeAttendence(EmpId, DateOfAttendence);
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
            var leaves = this._leaveRepository.GetEmployeePendingLeaves();
            return View(leaves);
        }

        [HttpPost]
        public ActionResult StatusForLeave(int leaveId, string status)
        {
            EmployeeLeave leave= this._leaveRepository.GetById(leaveId);
            leave.Status = status;
            this._leaveRepository.Update(leave);
            return Json("Success");
        }
    }
}