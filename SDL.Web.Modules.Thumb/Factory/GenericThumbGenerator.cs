using SDL.Web.Modules.Thumb.Models;
using System;
using System.Configuration;

namespace SDL.Web.Modules.Thumb.Factory
{
    class GenericThumbGenerator : IThumbGenerator
    {
        readonly string _defaultThumbPath = ConfigurationManager.AppSettings["defaultThumbPath"];
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
            return _defaultThumbPath;
        }
    }
}
