using System;
using Sdl.Web.Common.Models;
using Sdl.Web.Modules.Core.Models;

namespace Sdl.Web.Site.Areas.HackathonDemo.Models
{
    [SemanticEntity(Vocab = CoreVocabulary, EntityName = "images", Prefix = "tri", Public = true)]
    [Serializable]
    [SemanticDefaults(MapAllProperties = false)]
    public class image:EntityModel
    {
        [SemanticProperty("tri:smallImage")]
        public Image SmallImage { get; set; }
        [SemanticProperty("tri:largeImage")]
        public Image LargeImage { get; set; }
        [SemanticProperty("tri:thumbnailImage")]
        public Image ThumbnailImage { get; set; }
        [SemanticProperty("tri:Image")]
        public Image Image { get; set; }

      
        [SemanticProperty("tri:altText")]
        public string AltText { get; set; }

        [SemanticProperty("tri:isBackground")]
        public string IsBackground { get; set; }

        [SemanticProperty("tri:externalLink")]
        public string ExternalLink { get; set; }

        [SemanticProperty("tri:internalLink")]
        public string InternalLink { get; set; }

        [SemanticProperty("tri:documentLink")]
        public Image DocumentLink { get; set; }

        [SemanticProperty("tri:openIn")]
        public string OpenIn { get; set; }

      
        
    }
}