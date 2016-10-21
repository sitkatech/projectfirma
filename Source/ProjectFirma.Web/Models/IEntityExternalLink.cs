using System.Web;

namespace ProjectFirma.Web.Models
{
    public interface IEntityExternalLink
    {
        string ExternalLinkLabel { get; }
        string ExternalLinkUrl { get; }
        HtmlString GetExternalLinkAsUrl();
    }
}