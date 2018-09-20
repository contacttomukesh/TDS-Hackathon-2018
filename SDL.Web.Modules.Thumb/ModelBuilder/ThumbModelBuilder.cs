using Sdl.Web.Common.Configuration;
using Sdl.Web.Common.Logging;
using Sdl.Web.Common.Models;
using Sdl.Web.DataModel;
using Sdl.Web.Tridion.Mapping;
using SDL.Web.Modules.Thumb.Models;
using System;

namespace SDL.Web.Modules.Thumb.ModelBuilder
{
    class ThumbModelBuilder : IEntityModelBuilder
    {
        public void BuildEntityModel(ref EntityModel entityModel, EntityModelData entityModelData, Type baseModelType, Localization localization)
        {
            using (new Tracer(entityModel))
            {
                if (entityModel != null && entityModel is MediaFileItem)
                {
                    var mediaFile = (MediaFileItem)entityModel;
                    bool generateThumb = false;
                    if (mediaFile != null && bool.TryParse(mediaFile.GenerateThumbnail, out generateThumb) && generateThumb)
                    {
                        //Generate thumbnail and assign it's value to the model.
                        ThumbModelHelper modelHelper = new ThumbModelHelper();
                        modelHelper.GenerateThumb(mediaFile);
                    }
                }
            }
        }
    }
}
