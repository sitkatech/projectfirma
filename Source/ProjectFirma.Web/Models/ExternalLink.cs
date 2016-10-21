using System.Collections.Generic;
using System.Linq;
using System.Web;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public class ExternalLink : IEntityExternalLink
    {
        public string ExternalLinkLabel { get; private set; }
        public string ExternalLinkUrl { get; private set; }
        public HtmlString GetExternalLinkAsUrl()
        {
            return UrlTemplate.MakeHrefString(ExternalLinkUrl, ExternalLinkLabel, new Dictionary<string, string> { { "target", "_blank" } });
        }
        public string DisplayCssClass { get; set; }

        public ExternalLink(string externalLinkLabel, string externalLinkUrl, string displayCssClass)
        {
            ExternalLinkLabel = externalLinkLabel;
            ExternalLinkUrl = externalLinkUrl;
            DisplayCssClass = displayCssClass;
        }

        public static List<ExternalLink> CreateFromEntityExternalLink(List<IEntityExternalLink> entityExternalLinks)
        {
            return entityExternalLinks.Select(x => new ExternalLink(x.ExternalLinkLabel, x.ExternalLinkUrl, null)).ToList();
        }
    }
}