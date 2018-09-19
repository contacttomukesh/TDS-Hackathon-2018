using Sdl.Web.Common.Configuration;
using Sdl.Web.Common.Logging;
using Sdl.Web.Mvc.Configuration;
using SDL.Web.Modules.Thumb.Factory;
using SDL.Web.Modules.Thumb.Models;
using System;
using System.Web;
using System.Configuration;
using System.IO;

namespace SDL.Web.Modules.Thumb.ModelBuilder
{
    public class ThumbModelHelper
    {
        readonly string _thumbFolder = ConfigurationManager.AppSettings["thumbFolder"];
        public void GenerateThumb(MediaFileItem mediaFile)
        {
            string inputPath = GetFilePathFromUrl(mediaFile.Url, WebRequestContext.Localization);
            if (inputPath.Contains("\\" + _thumbFolder + "\\"))
            {
                FileInfo inputFileInfo = new FileInfo(inputPath);
                mediaFile.FileSize = inputFileInfo.Exists ? inputFileInfo.Length : mediaFile.FileSize;
            }
            mediaFile.MediaLocation = inputPath;
            string outputPath = HttpContext.Current.Server.MapPath("~/" + _thumbFolder + "/" + WebRequestContext.Localization.Id + WebRequestContext.Localization.Path + System.IO.Path.ChangeExtension(mediaFile.FileName, ".jpg"));
            FileInfo fileInfo = new FileInfo(outputPath);
            if (!System.IO.File.Exists(outputPath))
            {
                if (fileInfo.Directory != null && !fileInfo.Directory.Exists)
                {
                    fileInfo.Directory.Create();
                }
                if (!System.IO.File.Exists(inputPath))
                {
                    try
                    {
                        SiteConfiguration.ContentProvider.GetStaticContentItem(mediaFile.Url, WebRequestContext.Localization);
                    }
                    catch (Exception ex)
                    {
                        Log.Warn("No static content found: " + ex.StackTrace);
                    }
                }
            }
            mediaFile.ThumbLocation = outputPath;
            string thumbPath = outputPath;
            if (!System.IO.File.Exists(outputPath))
            {
                ThumbFactory thumb = new ThumbProvider();
                IThumbGenerator thumbGenerator = thumb.GetThumbGenerator(mediaFile.MimeType);
                thumbPath = thumbGenerator.GetThumb(mediaFile);
            }
            if (thumbPath.Contains("/"))
            {
                mediaFile.GeneratedThumbImage = thumbPath;
            }
            else
            {
                FileInfo thumbfileInfo = new FileInfo(mediaFile.ThumbLocation);
                string imageUrl = thumbfileInfo.Exists ? WebRequestContext.Localization.Path + "/" + _thumbFolder + "/" + WebRequestContext.Localization.Id + WebRequestContext.Localization.Path + System.IO.Path.ChangeExtension(mediaFile.FileName, ".jpg") : "/thumbimages/default/thumbnail-pdf.jpg";
                mediaFile.GeneratedThumbImage = imageUrl;
            }
        }

        public string GetFilePathFromUrl(string urlPath, Localization loc)
        {
            var validPath = loc.BinaryCacheFolder + Uri.UnescapeDataString(urlPath);
            var absolutePath = HttpContext.Current.Server.MapPath("~/" + validPath);
            return (string.IsNullOrEmpty(absolutePath)) ?
                string.Format("{0}/{1}", loc.BinaryCacheFolder, validPath) :
                absolutePath;
        }

    }
}
