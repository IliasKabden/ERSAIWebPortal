using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public partial class AppUserDTO
    {
        public string ID { get; set; }
        public string UserName { get; set; }
        public IEnumerable<string> RoleIDs { get; set; }
        public AppUserAdditionalData AddData { get; set; }

        public string NewPassword { get; set; }
    }
    public partial class AppUserDTO
    {
        public AppUserDTO() { }
        public AppUserDTO(AppUser ef)
        {
            FromEF(ef);
        }
        public void FromEF(AppUser ef)
        {
            ID = ef.Id;
            UserName = ef.UserName;
            RoleIDs = ef.Roles.Select(r => r.RoleId);
            AddData = ef.AddData;
        }
    }
}