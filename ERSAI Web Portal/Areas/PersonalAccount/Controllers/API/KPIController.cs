using ERSAI_Web_Portal.Controllers.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ERSAI_Web_Portal.Areas.PersonalAccount.Controllers.API
{
    [Authorize(Roles = DataModels.AppRole.PersonalAccountRole), RoutePrefix("api/KPI")]
    public class KPIController : AppBaseApiController
    {
        [Route("MyKPIDocs")]
        public IQueryable<object> GetMyKPIDocs()
        {
            return ERSAIDB.KPIDocs
                .Where(doc => doc.Employee_BadgeNumber == User.Identity.Name)
                .OrderByDescending(doc => doc.Period_Year)
                .Select(doc => new
                {
                    Name = doc.Doc_Label,
                    Path = doc.FileDir + doc.FileName
                });
        }
        [Route("AnySubordinates"), HttpGet]
        public bool AnySubordinates()
        {
            return ERSAIDB.Employees.Any(emp => new[] { emp.SupervisorBadgeNumber, emp.ManagerBadgeNumber, emp.ApprovalManager_BadgeNumber }
                .Contains(User.Identity.Name));
        }
        [Route("MySubordinatesKPIDocs"), HttpPost]
        public IEnumerable<object> MySubordinatesDocs(DataModels.Models.Filters.SubordinatesKPIDocsFilter filter)
        {
            filter = filter ?? new DataModels.Models.Filters.SubordinatesKPIDocsFilter();
            filter.ClearEmptyProps();

            return (from doc in ERSAIDB.KPIDocs
                    join emp in ERSAIDB.Employees on doc.Employee_BadgeNumber equals emp.BadgeNumber
                    where
                        (filter.BadgeNumberLike == null || doc.Employee_BadgeNumber.Contains(filter.BadgeNumberLike))
                        &&
                        new[] { emp.SupervisorBadgeNumber, emp.ManagerBadgeNumber, emp.ApprovalManager_BadgeNumber }.Contains(User.Identity.Name)
                    select new { doc, emp })
                .ToList()
                .Select(x => new
                {
                    Name = x.doc.Doc_Label,
                    FullName = x.emp.FullName,
                    BadgeNumber = x.doc.Employee_BadgeNumber,
                    Path = x.doc.FileDir + x.doc.FileName
                });
        }
    }
}