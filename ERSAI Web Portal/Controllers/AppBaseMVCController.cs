using DataModels;
using ERSAI_Web_Portal.Models;
using ERSAI_Web_Portal.Models.DTO.Dicts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ERSAI_Web_Portal.Controllers
{
    public partial class AppBaseMVCController : Controller
    {
        private ERSAIContext _ERSAIDB;
        protected ERSAIContext ERSAIDB
        {
            get {
                _ERSAIDB = _ERSAIDB ?? new ERSAIContext();
                return _ERSAIDB;
            }
        }
        private PayslipContext _PayslipsDb;
        protected PayslipContext PayslipsDb
        {
            get {
                _PayslipsDb = _PayslipsDb ?? new PayslipContext();
                return _PayslipsDb;
            }
        }
        private IMSContext _IMSDB;
        protected IMSContext IMSDB
        {
            get {
                _IMSDB = _IMSDB ?? new IMSContext();
                return _IMSDB;
            }
        }

        private TravelContext _TRAVELDB;
        protected TravelContext TRAVELDB
        {
            get {
                _TRAVELDB = _TRAVELDB ?? new TravelContext();
                return _TRAVELDB;
            }
        }

        protected MvcApplication App
        {
            get {
                return MvcApplication.Current;
            }
        }
        protected AppUser AppUser
        {
            get {
                return ERSAIDB.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            }
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            ViewBag.AppUser = AppUser;

            var identity = User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                ViewBag.UserRoles = identity.Claims
                    .Where(c => c.Type == identity.RoleClaimType)
                    .Select(c => c.Value);
            }

            var dicts = new Dictionary<string, string>();
            _DictNamesToInclude.ForEach(dictName =>
            {
                var dict = MvcApplication.Current.Dicts[dictName];
                if (dict.JSON == null || (DateTime.Now - dict.LastRefreshTime)?.TotalSeconds >= 60)
                    dict.Refresh(Contexts);
                dicts[dictName] = dict.JSON;
            });
            ViewBag.Dicts = dicts;

            base.OnActionExecuted(filterContext);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _ERSAIDB?.Dispose();
                _IMSDB?.Dispose();
                _PayslipsDb?.Dispose();
                _TRAVELDB?.Dispose();
            }
            base.Dispose(disposing);
        }

        private List<string> _DictNamesToInclude = new List<string>();
        protected void RenderDictionaries(params string[] names)
        {
            _DictNamesToInclude.AddRange(names);
        }
        protected void SetAutoLogoutIfNoActivity(int AutoLogoutCountdownInSeconds = 60)
        {
            ViewBag.AutoLogoutCountdown = AutoLogoutCountdownInSeconds;
        }
        private MVCControllerDbContexts _Contexts;
        protected MVCControllerDbContexts Contexts
        {
            get {
                _Contexts = _Contexts ?? new MVCControllerDbContexts(this);
                return _Contexts;
            }
        }
        public class MVCControllerDbContexts
        {
            public MVCControllerDbContexts(AppBaseMVCController controller)
            {
                this.controller = controller;
            }
            private AppBaseMVCController controller;
            public IMSContext IMS
            {
                get {
                    return controller.IMSDB;
                }
            }
            public ERSAIContext ERSAI
            {
                get {
                    return controller.ERSAIDB;
                }
            }
            public PayslipContext Pasylips
            {
                get {
                    return controller.PayslipsDb;
                }
            }

            public TravelContext Travel
            {
                get {
                    return controller.TRAVELDB;
                }
            }

        }
    }
}