using System;
using System.Collections.Generic;
using Sdl.Web.Common.Models;
using SDL.Web.Modules.Thumb.Models;

namespace Sdl.Web.Site.Areas.HackathonDemo.Models
{
    [SemanticEntity(Vocab = CoreVocabulary, EntityName = "genericTile", Prefix = "tri", Public = true)]
    [Serializable]
    [SemanticDefaults(MapAllProperties = false)]
    public class GenericTile : EntityModel
    {
        [SemanticProperty("tri:heading")]
        public string Heading { get; set; }

        [SemanticProperty("tri:description")]
        public RichText Description { get; set; }

        [SemanticProperty("tri:tileCTA")]
        public List<CTA> TileCTA { get; set; }

        [SemanticProperty("tri:tileImage")]
        public image TileImage { get; set; }

        [SemanticProperty("tri:tileCustomCSS")]
        public Tag TileCustomCSS { get; set; }

        [SemanticProperty("tri:document")]
        public MediaFileItem documents { get; set; }
    }
}