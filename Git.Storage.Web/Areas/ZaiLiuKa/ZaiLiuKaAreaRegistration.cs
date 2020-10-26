using System.Web.Mvc;

namespace Git.Storage.Web.Areas.ZaiLiuKa
{
    public class ZaiLiuKaAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ZaiLiuKa";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ZaiLiuKa_default",
                "ZaiLiuKa/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
