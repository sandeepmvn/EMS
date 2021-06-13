using EMS.Model;
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

        public Payslip GetPayslipByEmpAndMonth(int empId,DateTime month)
        {
            return ds.Where(x => x.FKEmployeeId == empId && x.MonthDate == month).FirstOrDefault();
        }
    }
}
