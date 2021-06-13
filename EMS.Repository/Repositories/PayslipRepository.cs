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

        public PayslipVM GetPayslipByEmpAndMonth(int empId,DateTime month)
        {
            return ds.Select(x=>new PayslipVM()
            {
                EmployeeId=x.FKEmployeeId,
                MonthDate=x.MonthDate,
                CreditedOn=x.CreditedOn,
                Amount=x.Amount
            }).FirstOrDefault(x => x.EmployeeId == empId && x.MonthDate == month);
        }
    }
}
