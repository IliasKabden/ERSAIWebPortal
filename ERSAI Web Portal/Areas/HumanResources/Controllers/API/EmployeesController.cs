using DataModels;
using DataModels.Models.IMS.DTO;
using ERSAI_Web_Portal.Areas.HumanResources.Models;
using ERSAI_Web_Portal.Controllers.API;
using ERSAI_Web_Portal.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using static DataModels.Models.IMS.Employee;

namespace ERSAI_Web_Portal.Areas.HumanResources.Controllers.API
{
    [Authorize, RoutePrefix("api/Employees")]
    public partial class EmployeesController : AppBaseApiController
    {
        [Route("{BadgeNumber}"), Authorize(Roles = AppRole.HREmployeesCreatorRole + ", " + AppRole.HREmployeesViewerRole + ", " + AppRole.HREmployeesEditorRole)]
        public EmployeeDTO GetFullEmployeeData(string BadgeNumber)
        {
            var employee = IMSDB.Employees.Find(BadgeNumber);
            if (employee == null)
                return null;

            if (!User.IsInRole(AppRole.HREmployeesCreatorRole) && UserAddData?.IMSEmployeesBusinessUnitsViewRights != null && !UserAddData.IMSEmployeesBusinessUnitsViewRights.Contains(employee.BusinessUnitID))
                throw new Exception("You have no rights to view this employee's information");

            return new EmployeeDTO(employee, UserAddData?.IMSEmployeeSectionViewRights);
        }
        [Route("SaveNew"), HttpPost, Authorize(Roles = AppRole.HREmployeesCreatorRole)]
        public EmployeeDTO SaveNewEmployee(EmployeeDTO dto)
        {
            if (!UserAddData?.IMSEmployeesBusinessUnitsEditRights?.Contains(dto.BasicCompanyInfo?.BusinessUnitID) ?? false)
                throw new Exception("You have no rights to edit employees of this business unit");

            var emp = IMSDB.Employees.Add(new DataModels.Models.IMS.Employee());
            emp.FromDTO(dto, UserAddData?.IMSEmployeeSectionEditRights);

            var results = new List<ValidationResult>();
            var context = new ValidationContext(emp);
            if (!Validator.TryValidateObject(emp, context, results, true))
            {
                throw new Exception(string.Join(", ", results.Select(er => er.ErrorMessage)));
            }

            IMSDB.SaveChanges();
            if (dto.BasicInfo.PhotoBase64 != null)
                App.PhotoRepository.SaveEmployeePhotoFromBase64(dto.BasicInfo.BadgeNumber, dto.BasicInfo.PhotoBase64);
            else
                App.PhotoRepository.DeleteEmployeePhotoIfExists(dto.BasicInfo.BadgeNumber);
            IMSDB.Entry(emp).Reload();
            dto.FromEF(emp);
            return dto;
        }
        [Route("SaveUpdated"), HttpPost, Authorize(Roles = AppRole.HREmployeesEditorRole + ", " + AppRole.HREmployeesCreatorRole)]
        public EmployeeDTO SaveUpdatedEmployee(EmployeeDTO dto)
        {
            var emp = IMSDB.Employees.Find(dto.BasicInfo.BadgeNumber);
            if (!UserAddData?.IMSEmployeesBusinessUnitsEditRights?.Contains(emp.BusinessUnitID) ?? false)
                throw new Exception("You have no rights to edit employees of this business unit");


            emp.FromDTO(dto, UserAddData?.IMSEmployeeSectionEditRights);

            var results = new List<ValidationResult>();
            var context = new ValidationContext(emp);
            if (!Validator.TryValidateObject(emp, context, results, true))
            {
                throw new Exception(string.Join(", ", results.Select(er => er.ErrorMessage)));
            }

            IMSDB.SaveChanges();

            IMSDB.Entry(emp).Reload();
            dto.FromEF(emp, User.IsInRole(AppRole.HREmployeesCreatorRole) ? null : UserAddData?.IMSEmployeeSectionViewRights);
            return dto;
        }
        [Route("GetList"), HttpPost, Authorize(Roles = AppRole.HREmployeesCreatorRole + ", " + AppRole.HREmployeesViewerRole + ", " + AppRole.HREmployeesEditorRole)]
        public PaginatedResults<EmployeeDTO> GetEmployees(EmployeesFilter filter)
        {
            filter.BusinessUnitIDs = UserAddData?.IMSEmployeesBusinessUnitsViewRights;

            filter.NormalizeValues();
            var query = filter.Apply(IMSDB.Employees);
            var result = filter.ApplyPagination(query, ef => new EmployeeDTO()
            {
                BasicInfo = new EmployeeDTO.BasicInfoDTO(ef),
                BasicCompanyInfo = new EmployeeDTO.BasicCompanyInfoDTO(ef),
                StatusInfo = new EmployeeDTO.StatusInfoDTO(ef)
            });
            return result;
        }
    }
    public partial class EmployeesController
    {
        private AppUserAdditionalData _UserAddData;
        private AppUserAdditionalData UserAddData
        {
            get
            {
                if (_UserAddData == null)
                    _UserAddData = AppUser?.AddData;
                return _UserAddData;
            }
        }
    }
}