using Sdl.Web.Common.Logging;
using Sdl.Web.Common.Models;
using Sdl.Web.Mvc.Controllers;
using SDL.Web.Modules.Thumb.ModelBuilder;
using SDL.Web.Modules.Thumb.Models;

namespace SDL.Web.Modules.Thumb.Controllers
{
    /// <summary>
    /// Custom controller to generate thumbnail of files
    /// </summary>
	public class ThumbController : EntityController
    {
        /// <summary>
        /// Create the thumbnail and enrich the view model.
        /// </summary>
        protected override ViewModel EnrichModel(ViewModel model)
        {
            using (new Tracer(model))
            {
                MediaFileItem mediaFile = model as MediaFileItem;
                bool generateThumb = false;
                if (mediaFile != null && bool.TryParse(mediaFile.GenerateThumbnail, out generateThumb) && generateThumb)
                {
                    ThumbModelHelper modelHelper = new ThumbModelHelper();
                    modelHelper.GenerateThumb(mediaFile);
                }
                return mediaFile;
            }
        }

    }
}
