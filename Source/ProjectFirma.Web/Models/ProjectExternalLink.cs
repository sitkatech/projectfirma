using System.Collections.Generic;
using System.Web;
using ProjectFirma.Web.Common;
using LtInfo.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectExternalLink : IAuditableEntity, IEntityExternalLink
    {
        public string AuditDescriptionString
        {
            get
            {
                var project = HttpRequestStorage.DatabaseEntities.Projects.Find(ProjectID);
                var projectName = project != null ? project.AuditDescriptionString : ViewUtilities.NotFoundString;
                return string.Format("Project: {0}, External Link Label: {1}, External Link Url: {2}", projectName, ExternalLinkLabel, ExternalLinkLabel);
            }
        }

        public HtmlString GetExternalLinkAsUrl()
        {
            return UrlTemplate.MakeHrefString(ExternalLinkUrl, ExternalLinkLabel, new Dictionary<string, string> {{"target", "_blank"}});
        }
    }
}