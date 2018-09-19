using Microsoft.Office.Interop.Word;
using Sdl.Web.Common.Logging;
using SDL.Web.Modules.Thumb.Models;
using System;
using System.Configuration;
using System.Drawing;
using System.IO;

namespace SDL.Web.Modules.Thumb.Factory
{
    class WordThumbGenerator : IThumbGenerator
    {
        readonly string _wordThumbPath = ConfigurationManager.AppSettings["wordThumbPath"];
        public void DeleteThumb(string thumbPath)
        {
            throw new NotImplementedException();
        }

        public string GenerateThumb(MediaFileItem mediaFile)
        {
            using (new Tracer(mediaFile))
            {
                try
                {
                    var doc = new Microsoft.Office.Interop.Word.Application().Documents.Open(FileName: mediaFile.MediaLocation, Visible: false, ReadOnly: true);

                    doc.ShowGrammaticalErrors = false;
                    doc.ShowRevisions = false;
                    doc.ShowSpellingErrors = false;

                    byte[] bytes = doc.Range().EnhMetaFileBits;

                    Image page = Image.FromStream(new MemoryStream(bytes));

                    doc.Close(WdSaveOptions.wdDoNotSaveChanges);
                    Helper.Helper.GetThumb(page, mediaFile.Width, mediaFile.Height);
                }
                catch (Exception ex)
                {

                }
                return _wordThumbPath;
            }
        }

        public string GetThumb(MediaFileItem mediaFile)
        {
            if (mediaFile != null)
                return this.GenerateThumb(mediaFile);
            return _wordThumbPath;
        }
    }
}
