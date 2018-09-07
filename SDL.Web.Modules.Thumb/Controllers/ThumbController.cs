using Sdl.Web.Common.Configuration;
using Sdl.Web.Common.Logging;
using Sdl.Web.Common.Models;
using Sdl.Web.Mvc.Configuration;
using Sdl.Web.Mvc.Controllers;
using SDL.Web.Modules.Thumb.Factory;
using SDL.Web.Modules.Thumb.Models;
using System;
using System.Configuration;
using System.IO;
using System.Web.Mvc;

namespace SDL.Web.Modules.Thumb.Controllers
{
    /// <summary>
    /// Custom controller to generate thumbnail of files
    /// </summary>
	public class ThumbController : EntityController
    {
        readonly string _thumbFolder = ConfigurationManager.AppSettings["thumbFolder"];
        /// <summary>
        /// Enrich the View Model with request querystring parameters and populate the results using a configured Search Provider.
        /// </summary>
        [HandleSectionError(View = "SectionError")]
        public override ActionResult Entity(EntityModel entity, int containerSize = 0)
        {
            SetupViewData(entity, containerSize);
            ViewModel model = base.EnrichModel(entity);
            var mediaFile = EnrichModel(model);
            ViewData.Model = model;
            return View(model.MvcData.ViewName, model);
            //return mediaFile;
            //}
        }
        //Get Image Url

        protected override ViewModel EnrichModel(ViewModel model)
        {
            MediaFileItem mediaFile = model as MediaFileItem;
            if (mediaFile != null && mediaFile.GenerateThumbnail.Equals("true"))
            {
                string inputPath = GetFilePathFromUrl(mediaFile.Url, WebRequestContext.Localization);
                if (inputPath.Contains("\\" + _thumbFolder + "\\"))
                {
                    FileInfo inputFileInfo = new FileInfo(inputPath);
                    mediaFile.FileSize = inputFileInfo.Exists ? inputFileInfo.Length : mediaFile.FileSize;
                }
                mediaFile.MediaLocation = inputPath;
                string outputPath = Server.MapPath("~/" + _thumbFolder + "/" + WebRequestContext.Localization.Id + WebRequestContext.Localization.Path + System.IO.Path.ChangeExtension(mediaFile.FileName, ".jpg"));
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
            return mediaFile;
            //}           
        }
        
        public string GetFilePathFromUrl(string urlPath, Localization loc)
        {
            var validPath = loc.BinaryCacheFolder+Uri.UnescapeDataString(urlPath);
            var absolutePath = Server.MapPath("~/" + validPath);
            return (string.IsNullOrEmpty(absolutePath)) ?
                string.Format("{0}/{1}", loc.BinaryCacheFolder, validPath) :
                absolutePath;
        }
    }
}
