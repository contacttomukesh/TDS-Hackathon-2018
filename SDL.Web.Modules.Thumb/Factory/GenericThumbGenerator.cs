using SDL.Web.Modules.Thumb.Models;
using System;

namespace SDL.Web.Modules.Thumb.Factory
{
    class GenericThumbGenerator : IThumbGenerator
    {
        public void DeleteThumb(string thumbPath)
        {
            throw new NotImplementedException();
        }

        public string GenerateThumb(MediaFileItem mediaFile)
        {
            throw new NotImplementedException();
        }

        public string GetThumb(MediaFileItem mediaFile)
        {
            return "/thumbimages/default/thumbnail-default.jpg";
        }
    }
}
