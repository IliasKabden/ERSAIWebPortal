using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace ERSAI_Web_Portal
{
    public class CultureConfig
    {
        private static CultureInfo Culture;
        static CultureConfig()
        {
            Culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            Culture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            Culture.DateTimeFormat.DateSeparator = "/";
        }
        public static void Configure()
        {
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = Culture;
        }
    }
}