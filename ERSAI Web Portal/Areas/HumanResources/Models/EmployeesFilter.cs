using ERSAI_Web_Portal.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataModels.Models.IMS;

namespace ERSAI_Web_Portal.Areas.HumanResources.Models
{
    public class EmployeesFilter : PaginatedFilterBase<Employee>
    {
        public OrderByEnum OrderBy { get; set; }
        public bool OrderReverse { get; set; }
        public string BadgeLike { get; set; }
        public string BusinessUnitID { get; set; }
        public string Gender { get; set; }
        public string FullNameLike { get; set; }
        public string DepartmentID { get; set; }
        public short? ContractPositionID { get; set; }
        public string ContractPositionNameLike { get; set; }
        public short? StatusID { get; set; }
        public string Category { get; set; }

        public List<string> BusinessUnitIDs { get; set; }
        public override IQueryable<Employee> Apply(IQueryable<Employee> query)
        {
            if (BusinessUnitIDs != null)
                query = query.Where(emp => BusinessUnitIDs.Contains(emp.BusinessUnitID));
            if (BadgeLike != null)
                query = query.Where(emp => emp.BadgeNumber.Contains(BadgeLike));
            if (BusinessUnitID != null)
                query = query.Where(emp => emp.BusinessUnitID == BusinessUnitID);
            if (Gender != null)
                query = query.Where(emp => emp.Gender == Gender);
            if (FullNameLike != null)
                query = query.Where(emp => (emp.FirstName + " " + emp.MiddleName + " " + emp.LastName)
                    .Replace("  ", " ")
                    .ToLower()
                    .Contains(FullNameLike.ToLower()));
            if (DepartmentID != null)
                query = query.Where(emp => emp.DepartmentID == DepartmentID);
            if (ContractPositionID != null)
                query = query.Where(emp => emp.ContractPositionID == ContractPositionID);
            if (ContractPositionNameLike != null)
                query = query.Where(emp => emp.ContractPosition.Name.ToLower().Contains(ContractPositionNameLike.ToLower()));
            if (StatusID != null)
                query = query.Where(emp => emp.StatusID == StatusID);
            if (Category != null)
                query = query.Where(emp => emp.Category == Category);
            return OrderReverse
                ? query.OrderByDescending(OrderByExpressions[OrderBy])
                : query.OrderBy(OrderByExpressions[OrderBy]);
        }

        public enum OrderByEnum
        {
            Badge,
            LastName
        }
        private static Dictionary<OrderByEnum, System.Linq.Expressions.Expression<Func<Employee, object>>> OrderByExpressions = new Dictionary<OrderByEnum, System.Linq.Expressions.Expression<Func<Employee, object>>>
        {
            { OrderByEnum.Badge, e => e.BadgeNumber },
            { OrderByEnum.LastName, e => e.LastName }
        };

        public override void NormalizeValues()
        {
            base.NormalizeValues();

            if (string.IsNullOrWhiteSpace(BadgeLike))
                BadgeLike = null;
            if (string.IsNullOrWhiteSpace(FullNameLike))
                FullNameLike = null;
            if (string.IsNullOrWhiteSpace(ContractPositionNameLike))
                ContractPositionNameLike = null;
            if (BusinessUnitIDs != null && !BusinessUnitIDs.Contains(BusinessUnitID))
            {
                BusinessUnitID = null;
            }
        }
    }
}