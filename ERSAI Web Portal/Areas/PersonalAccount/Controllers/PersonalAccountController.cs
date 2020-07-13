using DataModels;
using ERSAI_Web_Portal.Areas.PersonalAccount.Models;
using ERSAI_Web_Portal.Controllers;
using ERSAI_Web_Portal.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERSAI_Web_Portal.Areas.PersonalAccount.Controllers
{
    [Authorize]
    public class PersonalAccountController : AppBaseMVCController
    {
        internal const string NoAvatarImageRelativePath = "~/Content/noAvatar.png";
        [Authorize(Roles = AppRole.PersonalAccountRole)]
        public ActionResult Index()
        {
            var personalAccountUser = AppUser.PersonalAccountUser;
            var details = new PersonalDetailsVM();
            if (personalAccountUser.IMSEmployee != null)
                details.FromIMSEmployee(personalAccountUser.IMSEmployee);
            else if (personalAccountUser.ERSAIEmployee != null)
                details.FromERSAIEmployee(personalAccountUser.ERSAIEmployee);
            else
                details = null;

            SetAutoLogoutIfNoActivity(300);

            return View(details);
        }
        [Authorize(Roles = AppRole.PersonalAccountRole)]
        public ActionResult Photo()
        {
            var path = App.PhotoRepository.GetEmployeePhotoPath(User.Identity.Name);
            return File(System.IO.File.Exists(path) ? path : Server.MapPath(NoAvatarImageRelativePath), "image/*");
        }
        [Authorize(Roles = AppRole.PersonalAccountRole)]
        public FileContentResult PayslipPDF(DateTime date, string lang)
        {
            using (var mStream = PayslipPrinter.GetPayslipPDF(date.ToString("MMMM yyyy", CultureInfo.InvariantCulture).ToUpper(), User.Identity.Name, lang, System.Configuration.ConfigurationManager.ConnectionStrings["PayslipConnectionString"].ConnectionString))
            {
                Response.AppendHeader("Content-Disposition", "inline; filename=paySlip.pdf");
                return File(mStream.ToArray(), System.Net.Mime.MediaTypeNames.Application.Pdf);
            }
        }
    }
}