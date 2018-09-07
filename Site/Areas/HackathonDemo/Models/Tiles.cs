using System;
using Sdl.Web.Common.Models;

namespace Sdl.Web.Site.Areas.HackathonDemo.Models
{
    [SemanticEntity(Vocab = CoreVocabulary, EntityName = "tiles", Prefix = "tri", Public = true)]
    [Serializable]
    [SemanticDefaults(MapAllProperties = false)]
    public class Tiles:EntityModel
    {
        [SemanticProperty("tri:heading")]
        public string Heading { get; set; }

        [SemanticProperty("tri:genericTiles")]
        public GenericTile GenericTiles { get; set; }

        [SemanticProperty("tri:size")]
        public Tag Size { get; set; }
    }
}