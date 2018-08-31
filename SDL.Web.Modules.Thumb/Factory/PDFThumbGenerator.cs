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
            FileInfo fileInfo = new FileInfo(mediaFile.ThumbLocation);
            string imageUrl = fileInfo.Exists ? WebRequestContext.Localization.Path + "/thumbimages/" + WebRequestContext.Localization.Id + WebRequestContext.Localization.Path + "/thumb/" + System.IO.Path.ChangeExtension(mediaFile.FileName, ".jpg") : "/Content/images/2006/downloads/thumbnail-pdf.jpg"; ;
            return imageUrl;
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
