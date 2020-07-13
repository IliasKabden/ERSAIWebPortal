using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ERSAI_Web_Portal.Controllers
{
    [Authorize]
    public class HomeController : AppBaseMVCController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}