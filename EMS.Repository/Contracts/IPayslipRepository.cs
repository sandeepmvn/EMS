using EMS.Model;
using EMS.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Repository
{
    public interface IPayslipRepository : IGenericRepository<Payslip>
    {
        List<PayslipVM> GetAllPaySlips();

        PayslipVM GetPayslipById(int id);
        PayslipVM GetPayslipByEmpAndMonth(int empId, DateTime month);
        void AddUpdatePayslip(PayslipVM payslip);
        void UpdatePayslip(PayslipVM payslip);

    }
}
