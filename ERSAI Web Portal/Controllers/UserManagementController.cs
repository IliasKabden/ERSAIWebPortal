using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERSAI_Web_Portal.Controllers
{
    [Authorize(Roles = AppRole.UsersManagerRole)]
    public class UserManagementController : AppBaseMVCController
    {
        public ActionResult Index()
        {
            RenderDictionaries(DictsConfig.UMDictName);
            return View();
        }
    }
}