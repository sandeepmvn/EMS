using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EMS.Model;
using EMS.Repository;

namespace EMS.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PayslipsController : Controller
    {
        //private EMSContext db = new EMSContext();
        private IPayslipRepository _payslipRepository;

        public PayslipsController()
        {
            this._payslipRepository = new PayslipRepository(new EMSContext());
        }

        // GET: Admin/Payslips
        public ActionResult Index()
        {
            return View(this._payslipRepository.GetAll());
        }

        // GET: Admin/Payslips/Details/5
        public ActionResult Details(int id)
        {
            Payslip payslip = this._payslipRepository.GetById(id);
            if (payslip == null)
            {
                return HttpNotFound();
            }
            return View(payslip);
        }

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
        public ActionResult Create(Payslip payslip)
        {
            if (ModelState.IsValid)
            {
                payslip.CreditedOn = DateTime.Now;
                this._payslipRepository.Add(payslip);
                return RedirectToAction("Index");
            }

            return View(payslip);
        }

        // GET: Admin/Payslips/Edit/5
        public ActionResult Edit(int id)
        {
            Payslip payslip = this._payslipRepository.GetById(id);
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
        public ActionResult Edit(Payslip payslip)
        {
            if (ModelState.IsValid)
            {
                payslip.CreditedOn = DateTime.Now;
                this._payslipRepository.Update(payslip);
                return RedirectToAction("Index");
            }
            return View(payslip);
        }

        // GET: Admin/Payslips/Delete/5
        public ActionResult Delete(int id)
        {
            Payslip payslip = this._payslipRepository.GetById(id);
            if (payslip == null)
            {
                return HttpNotFound();
            }
            return View(payslip);
        }

        // POST: Admin/Payslips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            this._payslipRepository.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
