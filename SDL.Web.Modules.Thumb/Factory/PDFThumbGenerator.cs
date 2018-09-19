using GhostscriptSharp;
using Sdl.Web.Common.Logging;
using Sdl.Web.Mvc.Configuration;
using SDL.Web.Modules.Thumb.Models;
using System;
using System.IO;

namespace SDL.Web.Modules.Thumb.Factory
{
    public class PDFThumbGenerator : IThumbGenerator
    {
        /// <summary>
        /// Create thumbnail of pdf file
        /// </summary>
        /// <param name="mediaFile">pdf file object</param>
        public string GenerateThumb(MediaFileItem mediaFile)
        {
            using (new Tracer())
            {
                try
                {
                    if (!string.IsNullOrEmpty(mediaFile.ThumbLocation))
                        GhostscriptWrapper.GeneratePageThumb(mediaFile.MediaLocation, mediaFile.ThumbLocation, 1, mediaFile.Width, mediaFile.Height);
                }
                catch (Exception ex)
                {
                    Log.Error(ex);
                }
                return mediaFile.ThumbLocation;
            }
        }

        public void DeleteThumb(string thumbPath)
        {
            throw new NotImplementedException();
        }

        public string GetThumb(MediaFileItem mediaFile)
        {
            if (mediaFile != null)
                return this.GenerateThumb(mediaFile);
            return "";
        }
    }
}
