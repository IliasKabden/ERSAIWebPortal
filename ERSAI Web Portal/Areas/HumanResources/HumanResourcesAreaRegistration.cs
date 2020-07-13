using System.Web.Mvc;

namespace ERSAI_Web_Portal.Areas.HumanResources
{
    public class HumanResourcesAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return AreaNames.HumanResources;
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                $"{AreaNames.HumanResources}_default",
                AreaNames.HumanResources + "/{controller}/{action}/{ID}",
                new { action = "Index", ID = UrlParameter.Optional }
            );
        }
    }
}