using EMS.BO;
using EMS.Model;
using EMS.Model.PartialClass;
using EMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EMS.Areas.Admin.Controllers
{
    public class AuthenticateController : Controller
    {
        //UserProfileBO userProfileBO = new UserProfileBO();

        private IUserProfileRepository _userProfileRepository;

        public AuthenticateController()
        {
            this._userProfileRepository = new UserProfileRepository(new EMSContext());
        }
        [HttpGet]
        // GET: Admin/Authenticate
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel userDetail)
        {
            if (ModelState.IsValid)
            {
                userDetail = this._userProfileRepository.Authenticate(userDetail);
                if (userDetail.IsValid)
                {
                    FormsAuthentication.SetAuthCookie(userDetail.EmailId, false);
                    return RedirectToAction("Index", "UserProfile");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "The emailId or password is incorrect");
                }
            }
            
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}