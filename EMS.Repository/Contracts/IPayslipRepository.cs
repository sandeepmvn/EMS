using EMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Repository
{
    public interface IPayslipRepository : IGenericRepository<Payslip>
    {
        Payslip GetPayslipByEmpAndMonth(int empId, DateTime month);
    }
}
