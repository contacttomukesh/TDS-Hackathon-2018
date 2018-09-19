using SDL.Web.Modules.Thumb.Models;
using System;
using System.Configuration;

namespace SDL.Web.Modules.Thumb.Factory
{
    class ExcelThumbGenerator : IThumbGenerator
    {
        readonly string _excelThumbPath = ConfigurationManager.AppSettings["excelThumbPath"];
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
            return _excelThumbPath;
        }
    }
}
