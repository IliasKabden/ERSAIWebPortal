using ERSAI_Web_Portal.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataModels.Models.IMS;
using DataModels;

namespace ERSAI_Web_Portal.Models.DTO
{
    public class UsersFilter : PaginatedFilterBase<AppUser>
    {
        public string UsernameLike { get; set; }
        public string RoleID { get; set; }
        public override IQueryable<AppUser> Apply(IQueryable<AppUser> query)
        {
            query = query.Where(u => u.PersonalAccountUserID == null);

            if (UsernameLike != null)
                query = query.Where(u => u.UserName.ToLower().Contains(UsernameLike.ToLower()));
            if (RoleID != null)
                query = query.Where(u => u.Roles.Any(r => r.RoleId == RoleID));
            return query;
        }

        public override void NormalizeValues()
        {
            base.NormalizeValues();

            if (string.IsNullOrWhiteSpace(UsernameLike))
                UsernameLike = null;
        }
    }
}