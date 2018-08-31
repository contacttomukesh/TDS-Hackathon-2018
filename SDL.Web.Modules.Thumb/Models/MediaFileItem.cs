using Sdl.Web.Common.Models;
using System;

namespace SDL.Web.Modules.Thumb.Models
{
    [SemanticEntity(Vocab = CoreVocabulary, EntityName = "MultimediaFile", Prefix = "tri", Public = true)]
    [Serializable]
    [SemanticDefaults(MapAllProperties = false)]
    public partial class MediaFileItem : MediaItem
    {
        [SemanticProperty("tri:generateThumbnail")]
        public string GenerateThumbnail { get; set; }

        [SemanticProperty("tri:height")]
        public int Height { get; set; }

        [SemanticProperty("tri:width")]
        public int Width { get; set; }

        [SemanticProperty("tri:thumbImage")]
        public MediaItem ThumbImage { get; set; }       
        public string GeneratedThumbImage { get; set; }

        public string MediaLocation { get; set; }

        public string ThumbLocation { get; set; }

        [SemanticProperty("tri:description")]
        public string Description { get; set; }
        public override string ToHtml(string widthFactor, double aspect = 0, string cssClass = null, int containerSize = 0)
        {
            throw new NotImplementedException();
        }
    }
}
