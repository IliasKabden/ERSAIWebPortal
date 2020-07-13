using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using DataModels.ERSAI;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DataModels
{
    public class AppUser : IdentityUser<string, AppUserLogin, AppUserRole, AppUserClaim>
    {
        [Required]
        public override string UserName
        {
            get
            {
                return base.UserName;
            }

            set
            {
                base.UserName = value;
            }
        }
        [ForeignKey(nameof(PersonalAccountUser)), Column("PayslipUserID")]
        public string PersonalAccountUserID { get; set; }
        public virtual PersonalAccountUser PersonalAccountUser { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AppUser, string> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            if (ForPersonalCabinet)
            {
                foreach (var roleClaim in userIdentity.Claims.Where(c => c.Type == userIdentity.RoleClaimType))
                {
                    var result = userIdentity.TryRemoveClaim(roleClaim);
                }
                userIdentity.AddClaim(new Claim(userIdentity.RoleClaimType, AppRole.PersonalAccountRole));
            }
            return userIdentity;
        }
        public string _AdditionalJsonData { get; set; }
        [NotMapped]
        public AppUserAdditionalData AddData
        {
            get
            {
                return _AdditionalJsonData == null ? null : JsonConvert.DeserializeObject<AppUserAdditionalData>(_AdditionalJsonData);
            }
            set
            {
                _AdditionalJsonData = value == null ? null : JsonConvert.SerializeObject(value);
            }
        }

        [NotMapped]
        public bool ForPersonalCabinet { get; set; }

        public void FromDTO(AppUserDTO dto)
        {
            UserName = dto.UserName;

            Roles.Clear();
            dto.RoleIDs?.ToList().ForEach(roleID =>
            {
                Roles.Add(new AppUserRole()
                {
                    User = this,
                    RoleId = roleID
                });
            });

            AddData = dto.AddData;
        }
    }
    public class AppUserLogin : IdentityUserLogin { }
    public class AppRole : IdentityRole<string, AppUserRole>
    {
        public AppRole()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Description { get; set; }

        public const string
            PersonalAccountRole = "PersonalAccount",
            HREmployeesCreatorRole = "HREmployeesCreator",
            HREmployeesEditorRole = "HREmployeesEditor",
            HREmployeesViewerRole = "HREmployeesViewer",

            UsersManagerRole = "UsersManager";
    }
    public class AppUserRole : IdentityUserRole<string>
    {
        [ForeignKey(nameof(RoleId))]
        public virtual AppRole Role { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual AppUser User { get; set; }
    }
    public class AppUserClaim : IdentityUserClaim { }
    public class AppUserAdditionalData
    {
        public List<Models.IMS.Employee.ComplexInfoSection> IMSEmployeeSectionViewRights { get; set; }
        public List<Models.IMS.Employee.ComplexInfoSection> IMSEmployeeSectionEditRights { get; set; }

        public List<string> IMSEmployeesBusinessUnitsViewRights { get; set; }
        public List<string> IMSEmployeesBusinessUnitsEditRights { get; set; }
    }
}