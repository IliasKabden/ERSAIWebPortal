using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataModels;
using DataModels.Models.Travel;

namespace ERSAI_Web_Portal.Areas.Travel.Controllers
{
    public class TravelController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
