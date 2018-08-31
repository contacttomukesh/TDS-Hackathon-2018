using SDL.Web.Modules.Thumb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDL.Web.Modules.Thumb.Factory
{
    interface IThumbGenerator
    {
        string GenerateThumb(MediaFileItem mediaFile);

        string GetThumb(MediaFileItem mediaFile);

        void DeleteThumb(string thumbPath);

    }
}
