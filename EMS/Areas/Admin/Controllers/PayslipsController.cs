using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EMS.Model;
using EMS.Model.ViewModels;
using EMS.Repository;

namespace EMS.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PayslipsController : Controller
    {
        //private EMSContext db = new EMSContext();
        private IPayslipRepository _payslipRepository;
        private IUserProfileRepository _userProfileRepository;

        public PayslipsController()
        {
            this._userProfileRepository = new UserProfileRepository(new EMSContext());
            this._payslipRepository = new PayslipRepository(new EMSContext());
        }

        // GET: Admin/Payslips
        public ActionResult Index()
        {
            return View(this._payslipRepository.GetAllPaySlips());
        }

        //public ActionResult Details(int id)
        //{
        //    PayslipVM payslip = this._payslipRepository.GetPayslipById(id);
        //    if (payslip == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(payslip);
        //}

        // GET: Admin/Payslips/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Payslips/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PayslipVM payslip)
        {
            if (ModelState.IsValid)
            {
                var obj=this._userProfileRepository.GetEmployeeByEmpId(payslip.EmployeeId);
                if (obj != null)
                {
                    this._payslipRepository.AddUpdatePayslip(payslip);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "EmployeeId doesnot exist.");
                }
            }

            return View(payslip);
        }

        // GET: Admin/Payslips/Edit/5
        public ActionResult Edit(int id)
        {
            PayslipVM payslip = this._payslipRepository.GetPayslipById(id);
            if (payslip == null)
            {
                return HttpNotFound();
            }
            return View(payslip);
        }

        // POST: Admin/Payslips/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PayslipVM payslip)
        {
            if (ModelState.IsValid)
            {
                var obj = this._userProfileRepository.GetEmployeeByEmpId(payslip.EmployeeId);
                if (obj != null)
                {
                    this._payslipRepository.UpdatePayslip(payslip);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "EmployeeId doesnot exist.");
                }
            }
            return View(payslip);
        }

        // POST: Admin/Payslips/Delete/5
        public ActionResult DeletePayslip(int id)
        {
            this._payslipRepository.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
