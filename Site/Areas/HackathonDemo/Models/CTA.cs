using System;
using Sdl.Web.Common.Models;
using Sdl.Web.Modules.Core.Models;

namespace Sdl.Web.Site.Areas.HackathonDemo.Models
{
    [SemanticEntity(Vocab = CoreVocabulary, EntityName = "cta", Prefix = "tri", Public = true)]
    [Serializable]
    [SemanticDefaults(MapAllProperties = false)]
    public class CTA : EntityModel
    {
        [SemanticProperty("tri:title")]
        public string Title { get; set; }

        [SemanticProperty("tri:externalLink")]
        public string ExternalLink { get; set; }

        [SemanticProperty("tri:internalLink")]
        public string InternalLink { get; set; }

        [SemanticProperty("tri:documentLink")]
        public Image DocumentLink { get; set; }

        [SemanticProperty("tri:openIn")]
        public string OpenIn { get; set; }

        [SemanticProperty("tri:ctaBackground")]
        public Tag CtaBackground { get; set; }

        [SemanticProperty(":trictaCustomCSS")]
        public Tag CtaCustomCSS { get; set; }

        [SemanticProperty("tri:isLightBox")]
        public string IsLightBox { get; set; }

        [SemanticProperty("tri:mapLightBox")]
        public Tag MapLightBox { get; set; }

    }
}