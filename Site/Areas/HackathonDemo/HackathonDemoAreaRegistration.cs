using System.Web.Mvc;
using Sdl.Web.Common.Models;
using Sdl.Web.Mvc.Configuration;
using Sdl.Web.Modules.Core.Models;
using SDL.Web.Modules.Thumb.Models;

namespace Sdl.Web.Site.Areas.HackathonDemo
{
    public class HackathonDemoAreaRegistration : BaseAreaRegistration
    {
        public override string AreaName 
        {
            get 
            {
                return "HackathonDemo";
            }
        }

        //public override void RegisterArea(AreaRegistrationContext context) 
        //{
        //    context.MapRoute(
        //        "HackathonDemo_default",
        //        "HackathonDemo/{controller}/{action}/{id}",
        //        new { action = "Index", id = UrlParameter.Optional }
        //    );
        //}
        protected override void RegisterAllViewModels()
        {
            // Entity Views
      

            // Page Views
            //RegisterViewModel("IncludePage", typeof(PageModel));
            RegisterViewModel("Index", typeof(PageModel));
            RegisterViewModel("HomePage", typeof(Sdl.Web.Site.Areas.HackathonDemo.Models.TileCollection));
            // Region Views for Include Pages
            RegisterViewModel("Header", typeof(Link));
            RegisterViewModel("Footer", typeof(RegionModel));
            RegisterViewModel("FooterLinks", typeof(LinkList<Link>));
            RegisterViewModel("Contact", typeof(LinkList<Link>));
            RegisterViewModel("ThumbIcon", typeof(MediaFileItem), "Thumb");

        }
    }
}