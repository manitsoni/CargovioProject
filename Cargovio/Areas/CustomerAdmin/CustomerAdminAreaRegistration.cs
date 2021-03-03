using System.Web.Mvc;

namespace Cargovio.Areas.CustomerAdmin
{
    public class CustomerAdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "CustomerAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "CustomerAdmin_default",
                "CustomerAdmin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}