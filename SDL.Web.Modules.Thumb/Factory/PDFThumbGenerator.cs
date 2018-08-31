using GhostscriptSharp;
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
        /// <param name="inputFile">pdf file full path</param>
        /// <param name="thumbnailPath">thumbnail image full path</param>
        /// <param name="pageNo">page no of which to create thumbnail</param>
        /// <param name="width">Width of thumbnail</param>
        /// <param name="height">Height of thumbnail</param>
        public string GenerateThumb(MediaFileItem mediaFile)
        {
            try
            {
                if (!string.IsNullOrEmpty(mediaFile.ThumbLocation))
                    GhostscriptWrapper.GeneratePageThumb(mediaFile.MediaLocation, mediaFile.ThumbLocation, 1, mediaFile.Width, mediaFile.Height);
            }
            catch (Exception ex)
            {
                // Ignores to show the default thumb
            }
            return mediaFile.ThumbLocation;
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
