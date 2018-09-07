using Sdl.Web.Common.Models;
using System.Collections.Generic;
using SDL.Web.Modules.Thumb.Models;
using System;

namespace Sdl.Web.Site.Areas.HackathonDemo.Models
{
    [SemanticEntity(Vocab = CoreVocabulary, EntityName = "genericTileCollection", Prefix = "tri", Public = true)]
    [Serializable]
    [SemanticDefaults(MapAllProperties = false)]
    public class TileCollection : EntityModel
    {
        [SemanticProperty("tri:title")]
        public string Title { get; set; }

        [SemanticProperty("tri:description")]
        public RichText Description { get; set; }

        [SemanticProperty("tri:addnDescription")]
        public RichText AddnDescription { get; set; }

        [SemanticProperty("tri:tiles")]
        public List<Tiles> Tiles { get; set; }

        [SemanticProperty("tri:customCSS")]
        public Tag CustomCSS { get; set; }

        [SemanticProperty("tri:mapLightBox")]
        public Tag MapLightBox { get; set; }

        [SemanticProperty("tri:tileImage")]
        public image TileImage { get; set; }

        [SemanticProperty("tri:genericTiles")]
        public GenericTile GenericTiles { get; set; }

        public MediaFileItem mediaFileItem { get; set; }

    }
}