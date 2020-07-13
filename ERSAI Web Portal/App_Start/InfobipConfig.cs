using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERSAI_Web_Portal
{
    public class InfobipConfig
    {
        public static void Configure(MvcApplication app)
        {
            app.SMSClient = new IntegrationClients.InfobipClient(new Infobip.Api.Config.BasicAuthConfiguration("ERSAI", "Admin2017"), "ERSAI");
        }
    }
}