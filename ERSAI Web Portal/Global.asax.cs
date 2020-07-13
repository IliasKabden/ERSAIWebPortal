using DataModels;
using DataModels.Repositories.IMS;
using ERSAI_Web_Portal.Models.DTO.Dicts;
using IntegrationClients;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ERSAI_Web_Portal
{
    public class MvcApplication : HttpApplication
    {
        internal static MvcApplication Current { get; set; }
        internal SMTPClient SMTPClient { get; set; }
        internal InfobipClient SMSClient { get; set; }
        internal Dictionary<string, DictsDTO> Dicts = new Dictionary<string, DictsDTO>();
        internal EmployeePhotosRepository PhotoRepository;
        protected void Application_Start()
        {
            Current = this;

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            SMTPConfig.Configure(this);
            InfobipConfig.Configure(this);
            DictsConfig.Configure(this);

            Database.SetInitializer<ERSAIContext>(null);
            Database.SetInitializer<IMSContext>(null);
            Database.SetInitializer<PayslipContext>(null);

            PhotoRepository = new EmployeePhotosRepository()
            {
                EmployeePhotosMainDirectoryPath = ConfigurationManager.AppSettings["PersonalPhotosDirectory"] ?? "D:/PersonalPhotos"
            };
        }
        protected void Application_BeginRequest(object sender, System.EventArgs e)
        {
            CultureConfig.Configure();
        }

        private Microsoft.AspNet.Identity.IPasswordHasher _ASPIdentityPasswordHasher;
        internal Microsoft.AspNet.Identity.IPasswordHasher ASPIdentityPasswordHasher
        {
            get
            {
                return _ASPIdentityPasswordHasher;
            }
            set
            {
                _ASPIdentityPasswordHasher = value;
                if (_ASPIdentityPasswordHasher != null)
                    new DBSeeder().Seed();
            }
        }
    }
}