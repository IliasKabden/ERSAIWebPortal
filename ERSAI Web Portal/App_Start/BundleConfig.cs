using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Optimization;

namespace ERSAI_Web_Portal
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/polyfills").IncludeDirectory("~/Scripts/Polyfills", "*.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.mask.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.unobtrusive*",
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                "~/Scripts/knockout-{version}.js",
                "~/Scripts/knockout.validation.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/Scripts/sammy-{version}.js",
                "~/Scripts/app/common.js",
                "~/Scripts/app/BasicClass.item.es5.js",
                "~/Scripts/app/app.datamodel.js",
                "~/Scripts/app/app.viewmodel.js",
                "~/Content/air-datepicker/dist/js/datepicker.min.js",
                "~/Content/air-datepicker/dist/js/i18n/datepicker.en.js",
                "~/Scripts/app/PaginatedResults.es5.js",
                "~/Scripts/app/PaginatedFilter.js",
                "~/Scripts/app/_run.js",
                "~/Scripts/moment-with-locales.min.js")
                .IncludeDirectory("~/Scripts/app/KOCustomBindings", "*.js", true));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/Semantic-UI").Include(
                "~/Content/Semantic-UI/semantic.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/Semantic-UI/semantic.min.css",
                "~/Content/air-datepicker/dist/css/datepicker.min.css",
                "~/Content/Site.css"));
            #region Views
            bundles.Add(new ScriptBundle("~/bundles/views/home").Include(
                "~/Scripts/app/Views/home.viewmodel.js"));
            bundles.Add(new ScriptBundle("~/bundles/views/employees").IncludeDirectory(
                "~/Scripts/app/Views/Employees", "*.js"));
            bundles.Add(new ScriptBundle("~/bundles/views/UserManagement").IncludeDirectory(
                "~/Scripts/app/Views/UserManagement", "*.js"));
            #endregion
        }
    }
}