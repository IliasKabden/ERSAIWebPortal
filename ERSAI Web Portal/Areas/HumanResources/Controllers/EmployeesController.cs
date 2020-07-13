using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataModels;
using DataModels.Models.IMS;
using ERSAI_Web_Portal.Controllers;
using ClosedXML.Excel;
using System.IO;

namespace ERSAI_Web_Portal.Areas.HumanResources.Controllers
{
    [Authorize(Roles = AppRole.HREmployeesEditorRole + ", " + AppRole.HREmployeesCreatorRole + ", " + AppRole.HREmployeesViewerRole)]
    public class EmployeesController : AppBaseMVCController
    {
        public ActionResult Index()
        {
            RenderDictionaries(DictsConfig.HRDictName);
            return View();
        }
        public ActionResult Photo(string ID)
        {
            var path = App.PhotoRepository.GetEmployeePhotoPath(ID);
            return File(System.IO.File.Exists(path) ? path : Server.MapPath(PersonalAccount.Controllers.PersonalAccountController.NoAvatarImageRelativePath), "image/*");
        }
        public ActionResult GetExcelPrintForm(string Badge, string ReportName, string Parameters)
        {
            XLWorkbook workbook;
            switch (ReportName)
            {
                case "LeaveRequest":
                    {
                        workbook = Helpers.ExcelFormsHelper.GetLeaveRequestForm(IMSDB.Employees.Find(Badge));
                        break;
                    }
                default:
                    {
                        throw new Exception();
                    }
            }
            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                return File(stream.ToArray(), System.Net.Mime.MediaTypeNames.Application.Octet, $"{Badge}_{ReportName}.xlsx");
            }
        }
    }
}