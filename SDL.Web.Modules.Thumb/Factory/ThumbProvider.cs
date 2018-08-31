using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDL.Web.Modules.Thumb.Factory
{
    class ThumbProvider : ThumbFactory
    {
        private const string Xl = "application/ms-excel";
        private const string Xlx = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        private const string Zipc = "application/x-zip-compressed";
        private const string Zip = "application/zip";
        private const string Doc = "application/msword";
        private const string Docx = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
        private const string Pptx = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
        private const string Ppt = "application/ms-powerpoint";
        private const string Pdf = "application/pdf";
        public override IThumbGenerator GetThumbGenerator(string type)
        {
            switch (type)
            {
                case Pdf: return new PDFThumbGenerator();
                case Xl:
                case Xlx:
                    return new ExcelThumbGenerator();
                case Zip:
                case Zipc:
                    return new ZipThumbGenerator();
                case Doc:
                case Docx:
                    return new WordThumbGenerator();
                case Ppt:
                case Pptx:
                    return new PowerPointThumbGenerator();
                default:
                    return new GenericThumbGenerator();

            }
        }
    }
}
