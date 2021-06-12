using EMS.BO;
using EMS.Model.PartialClass;
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
        UserProfileBO userProfileBO = new UserProfileBO();
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
                userDetail = userProfileBO.Authenticate(userDetail);
                if (userDetail.IsValid)
                {
                    FormsAuthentication.SetAuthCookie(userDetail.EmailId, false);
                    return RedirectToAction("Index", "UserProfile");
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