using ERSAI_Web_Portal.Controllers.API;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ERSAI_Web_Portal.Areas.PersonalAccount.Controllers.API
{
    [Authorize(Roles = DataModels.AppRole.PersonalAccountRole)]
    public class PayslipsController : AppBaseApiController
    {
        public IQueryable<DateTime> GetMyPayslips()
        {
            return PayslipsDb.tbl_Employee.Where(e => e.EmpBadge == User.Identity.Name)
                .OrderByDescending(e => e.EmpTranDate)
                .Select(e => e.EmpTranDate);
        }
    }
}