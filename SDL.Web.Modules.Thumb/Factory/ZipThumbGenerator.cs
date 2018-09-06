using SDL.Web.Modules.Thumb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDL.Web.Modules.Thumb.Factory
{
    class ZipThumbGenerator : IThumbGenerator
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
            return "/thumbimages/default/thumbnail-zip.jpg";
        }
    }
}
