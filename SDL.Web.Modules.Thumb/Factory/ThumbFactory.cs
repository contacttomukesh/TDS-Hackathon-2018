using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDL.Web.Modules.Thumb.Factory
{
    abstract class ThumbFactory
    {
        public abstract IThumbGenerator GetThumbGenerator(string type);
    }
}
