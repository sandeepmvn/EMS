using EMS.CustomFilters;
using EMS.Model;
using EMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EMS.Controllers
{
    [JWTAuthorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Payslip")]
    public class PayslipController : ApiController
    {
        private IPayslipRepository _payslipRepository;
        public PayslipController()
        {
            this._payslipRepository = new PayslipRepository(new EMSContext());
        }

        [HttpGet]
        [Route("GetPayslipByEmpAndMonth/{empId}/{month}")]
        public IHttpActionResult GetPayslipByEmpAndMonth(int empId,DateTime month)
        {
            return Ok(this._payslipRepository.GetPayslipByEmpAndMonth(empId,month));
        }
    }
}
