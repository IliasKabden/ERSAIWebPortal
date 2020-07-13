using DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace ERSAI_Web_Portal
{
    public class DBSeeder
    {
        private ERSAIContext db = new ERSAIContext();
        public void Seed()
        {
            SeedRoles();
            var HRTestUser = new AppUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "HR",
                SecurityStamp = "asgfsagsagsag",
                PasswordHash = MvcApplication.Current.ASPIdentityPasswordHasher.HashPassword("123456")
            };
            HRTestUser.Roles.Clear();
            HRTestUser.Roles.Add(new AppUserRole()
            {
                UserId = HRTestUser.Id,
                RoleId = db.Roles.First(r => r.Name == AppRole.HREmployeesCreatorRole).Id
            });
            db.Users.AddOrUpdate(u => u.UserName, HRTestUser);

            HRTestUser = new AppUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "HREditor",
                SecurityStamp = "asdasfasf",
                PasswordHash = MvcApplication.Current.ASPIdentityPasswordHasher.HashPassword("123456"),
                AddData = new AppUserAdditionalData()
                {
                    IMSEmployeeSectionViewRights = new List<DataModels.Models.IMS.Employee.ComplexInfoSection>()
                    {
                        DataModels.Models.IMS.Employee.ComplexInfoSection.BasicInfo,
                        DataModels.Models.IMS.Employee.ComplexInfoSection.PassportInfo,
                        DataModels.Models.IMS.Employee.ComplexInfoSection.EmergencyContactInfo,
                        DataModels.Models.IMS.Employee.ComplexInfoSection.EducationInfo
                    },
                    IMSEmployeeSectionEditRights = new List<DataModels.Models.IMS.Employee.ComplexInfoSection>()
                    {
                        DataModels.Models.IMS.Employee.ComplexInfoSection.PassportInfo,
                        DataModels.Models.IMS.Employee.ComplexInfoSection.EmergencyContactInfo
                    },
                    IMSEmployeesBusinessUnitsViewRights = new List<string>()
                    {
                        "JANDG"
                    },
                    IMSEmployeesBusinessUnitsEditRights = new List<string>()
                    {
                        "JANDG"
                    }
                }
            };
            HRTestUser.Roles.Clear();
            HRTestUser.Roles.Add(new AppUserRole()
            {
                UserId = HRTestUser.Id,
                RoleId = db.Roles.First(r => r.Name == AppRole.HREmployeesEditorRole).Id
            });
            db.Users.AddOrUpdate(u => u.UserName, HRTestUser);

            var uManagerUser = new AppUser()
            {
                Id = "usersAdmin",
                UserName = "uAdmin",
                SecurityStamp = "asdasfasgfasgsa",
                PasswordHash = MvcApplication.Current.ASPIdentityPasswordHasher.HashPassword("123456789")
            };

            uManagerUser.Roles.Add(new AppUserRole()
            {
                UserId = uManagerUser.Id,
                RoleId = db.Roles.First(r => r.Name == AppRole.UsersManagerRole).Id
            });

            db.Users.AddOrUpdate(uManagerUser);

            db.SaveChanges();
        }
        private void SeedRoles()
        {
            db.Roles.AddOrUpdate(r => r.Name,
                new AppRole()
                {
                    Name = AppRole.HREmployeesEditorRole,
                    Description = "HR Employees Editor"
                },
                new AppRole()
                {
                    Name = AppRole.HREmployeesCreatorRole,
                    Description = "HR Employees Creator"
                },
                new AppRole()
                {
                    Name = AppRole.HREmployeesViewerRole,
                    Description = "HR Employees Viewer"
                },
                new AppRole()
                {
                    Name = AppRole.UsersManagerRole,
                    Description = "Users Manager"
                });
            db.SaveChanges();
        }
    }
}