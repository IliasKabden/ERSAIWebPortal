using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERSAI_Web_Portal
{
    public class SMTPConfig
    {
        public static void Configure(MvcApplication app)
        {
            app.SMTPClient = new IntegrationClients.SMTPClient("10.156.21.11", null, "sharepoint@ersai.kz");
        }
    }
}