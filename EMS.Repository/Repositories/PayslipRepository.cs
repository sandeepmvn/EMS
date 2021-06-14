using EMS.Model;
using EMS.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Repository
{
    public class PayslipRepository : GenericRepository<Payslip>, IPayslipRepository
    {
        public PayslipRepository(DbContext db) : base(db)
        {

        }

        public List<PayslipVM> GetAllPaySlips()
        {
            return ds.Select(x => new PayslipVM()
            {
                PKPayslipId = x.PKPayslipId,
                EmployeeId = x.FKEmployeeId,
                MonthDate = x.MonthDate,
                CreditedOn = x.CreditedOn,
                Amount = x.Amount
            }).ToList();
        }

        public PayslipVM GetPayslipById(int id)
        {
            return ds.Select(x => new PayslipVM()
            {
                PKPayslipId = x.PKPayslipId,
                EmployeeId = x.FKEmployeeId,
                MonthDate = x.MonthDate,
                CreditedOn = x.CreditedOn,
                Amount = x.Amount
            }).FirstOrDefault(x=>x.PKPayslipId==id);
        }

        public PayslipVM GetPayslipByEmpAndMonth(int empId, DateTime month)
        {

            return ds.Select(x => new PayslipVM()
            {
                PKPayslipId=x.PKPayslipId,
                EmployeeId = x.FKEmployeeId,
                MonthDate = x.MonthDate,
                CreditedOn = x.CreditedOn,
                Amount = x.Amount
            }).FirstOrDefault(x => x.EmployeeId == empId && x.MonthDate == month);
        }

        public void AddUpdatePayslip(PayslipVM payslipVM)
        {
            var data = ds.FirstOrDefault(x => x.FKEmployeeId == payslipVM.EmployeeId && x.MonthDate==payslipVM.MonthDate);
            if (data is null)
            {
                var payslip = new Payslip();
                payslip.FKEmployeeId = payslipVM.EmployeeId;
                payslip.MonthDate = payslipVM.MonthDate;
                payslip.CreditedOn = DateTime.Now;
                payslip.Amount = payslipVM.Amount;
                Add(payslip);
            }
            else
            {
                data.Amount = payslipVM.Amount;
                data.CreditedOn = DateTime.Now;
                Update(data);
            }

        }

        public void UpdatePayslip(PayslipVM payslipVM)
        {
            var data = ds.Find(payslipVM.PKPayslipId);
            data.FKEmployeeId = payslipVM.EmployeeId;
            data.MonthDate = payslipVM.MonthDate;
            data.CreditedOn = DateTime.Now;
            data.Amount = payslipVM.Amount;
            Update(data);
        }

    }
}
