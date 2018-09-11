using Sdl.Web.Mvc.Configuration;
using SDL.Web.Modules.Thumb.Models;

namespace SDL.Web.Modules.Thumb
{
    public class ThumbAreaRegistration : BaseAreaRegistration
    {
        public override string AreaName => "Thumb";
        protected override void RegisterAllViewModels()
        {
            // Thumb Entity Views
            RegisterViewModel("ThumbIcon", typeof(MediaFileItem), "Thumb");
        }
    }
}