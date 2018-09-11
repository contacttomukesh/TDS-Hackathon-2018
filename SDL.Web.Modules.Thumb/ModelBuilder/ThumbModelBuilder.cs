using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdl.Web.Common.Configuration;
using Sdl.Web.Common.Models;
using Sdl.Web.DataModel;
using Sdl.Web.Tridion;
using Sdl.Web.Tridion.Mapping;
using SDL.Web.Modules.Thumb.Models;

namespace SDL.Web.Modules.Thumb.ModelBuilder
{
    class ThumbModelBuilder : IEntityModelBuilder
    {
        public void BuildEntityModel(ref EntityModel entityModel, EntityModelData entityModelData, Type baseModelType, Localization localization)
        {
            if(entityModel != null && entityModel is MediaFileItem)
            {
                var mediaFile = (MediaFileItem)entityModel;
                if (mediaFile != null && mediaFile.GenerateThumbnail.Equals("true"))
                {
                    //Generate thumbnail and assign it's value to the model.
                    ThumbModelHelper modelHelper = new ThumbModelHelper();
                    modelHelper.GenerateThumb(mediaFile);
                }
            }
        }
    }
}
