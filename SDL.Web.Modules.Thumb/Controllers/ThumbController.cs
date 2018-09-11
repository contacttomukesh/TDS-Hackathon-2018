using Sdl.Web.Common.Models;
using Sdl.Web.Mvc.Controllers;
using SDL.Web.Modules.Thumb.ModelBuilder;
using SDL.Web.Modules.Thumb.Models;
using System.Web.Mvc;

namespace SDL.Web.Modules.Thumb.Controllers
{
    /// <summary>
    /// Custom controller to generate thumbnail of files
    /// </summary>
	public class ThumbController : EntityController
    {
        /// <summary>
        /// Enrich the View Model with request querystring parameters and populate the results using a configured Search Provider.
        /// </summary>
        [HandleSectionError(View = "SectionError")]
        public override ActionResult Entity(EntityModel entity, int containerSize = 0)
        {
            SetupViewData(entity, containerSize);
            ViewModel model = base.EnrichModel(entity);
            var mediaFile = EnrichModel(model);
            ViewData.Model = model;
            return View(model.MvcData.ViewName, model);
        }

        protected override ViewModel EnrichModel(ViewModel model)
        {
            MediaFileItem mediaFile = model as MediaFileItem;
            if (mediaFile != null && mediaFile.GenerateThumbnail.Equals("true"))
            {
                ThumbModelHelper modelHelper = new ThumbModelHelper();
                modelHelper.GenerateThumb(mediaFile);
            }
            return mediaFile;         
        }

    }
}
