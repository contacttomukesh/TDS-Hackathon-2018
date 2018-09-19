using SDL.Web.Modules.Thumb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDL.Web.Modules.Thumb.Factory
{
    class ZipThumbGenerator : IThumbGenerator
    {
        readonly string _zipThumbPath = ConfigurationManager.AppSettings["zipThumbPath"];
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
            return _zipThumbPath;
        }
    }
}
