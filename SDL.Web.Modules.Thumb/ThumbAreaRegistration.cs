using Sdl.Web.Mvc.Configuration;
using SDL.Web.Modules.Thumb.Models;

namespace SDL.Web.Modules.Thumb
{
    public class ThumbAreaRegistration : BaseAreaRegistration
    {
        public override string AreaName => "Thumb";

        //public override void RegisterArea(AreaRegistrationContext context)
        //{
        //    using (new Tracer(context, this))
        //    {
        //        // By default, class AreaRegistration assumes that the Controllers are in the same namespace as the concrete AreaRegistration subclass itself (or a sub namespace).
        //        // However, the DXA Core controllers are in the Sdl.Web.Mvc.Controllers namespace.
        //        context.Namespaces.Add("SDL.Web.Modules.Thumbnail.Controllers");

        //        base.RegisterArea(context);
        //    }
        //}
        protected override void RegisterAllViewModels()
        {
            // Thumb Entity Views
            RegisterViewModel("ThumbIcon", typeof(MediaFileItem), "Thumb");
        }
    }
}