using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectDocument : IAuditableEntity, IEntityDocument
    {
        public string AuditDescriptionString => $"Project \" {Project?.ProjectName ?? "<Not Found>"}\" document \"{DisplayName ?? "<Not Found>"}\"";
        public string DeleteUrl {
            get
            {
                return SitkaRoute<ProjectDocumentController>.BuildUrlFromExpression(x =>
                    x.Delete(ProjectDocumentID));
            }
        }
        public string EditUrl
        {
            get
            {
                return SitkaRoute<ProjectDocumentController>.BuildUrlFromExpression(x =>
                    x.Edit(ProjectDocumentID));
            }
        }
        public string DisplayCssClass { get; set; }
    }
}
