using DataModels;
using ERSAI_Web_Portal.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ERSAI_Web_Portal.Controllers.API
{
    [Authorize(Roles = AppRole.UsersManagerRole), RoutePrefix("api/UserManagement")]
    public class UserManagementController : AppBaseApiController
    {
        [Route("GetUsers"), HttpPost]
        public PaginatedResults<AppUserDTO> GetUsers(UsersFilter filter)
        {
            filter.NormalizeValues();
            var query = filter.Apply(ERSAIDB.Users);
            query = query.OrderBy(u => u.UserName);
            var result = filter.ApplyPagination(query, ef => new AppUserDTO(ef));
            return result;
        }
        [Route("SaveUser"), HttpPost]
        public AppUserDTO SaveUser(AppUserDTO dto)
        {
            if (ERSAIDB.Users.Any(u => u.UserName == dto.UserName && u.Id != dto.ID))
                throw new Exception("UserName has to be unique");

            var user = ERSAIDB.Users.Find(dto.ID) ?? ERSAIDB.Users.Add(new AppUser());
            user.FromDTO(dto);

            var results = new List<ValidationResult>();
            var context = new ValidationContext(user);
            if (!Validator.TryValidateObject(user, context, results, true))
            {
                throw new Exception(string.Join(", ", results.Select(er => er.ErrorMessage)));
            }

            user.Id = user.Id ?? Guid.NewGuid().ToString();

            if (dto.NewPassword != null)
            {
                user.PasswordHash = App.ASPIdentityPasswordHasher.HashPassword(dto.NewPassword);
                user.SecurityStamp = Guid.NewGuid().ToString();
            }

            ERSAIDB.SaveChanges();
            ERSAIDB.Entry(user).Reload();
            dto.FromEF(user);
            return dto;
        }
        [Route("DeleteUser/{UserID}"), HttpGet]
        public void DeleteUser(string UserID)
        {
            var user = ERSAIDB.Users.Find(UserID);
            if (user == null)
                throw new Exception("Wrong UserID");

            ERSAIDB.Users.Remove(user);
            ERSAIDB.SaveChanges();
        }
    }
}