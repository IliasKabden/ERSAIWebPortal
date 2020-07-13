using System.Web.Mvc;

namespace ERSAI_Web_Portal.Areas.PersonalAccount
{
    public class PersonalAccountAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return AreaNames.PersonalAccount;
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                $"{AreaNames.PersonalAccount}_default",
                AreaNames.PersonalAccount + "/{action}/{id}",
                new { controller = "PersonalAccount", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}