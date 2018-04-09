using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectDocumentUpdate : IEntityDocument
    {
        public string DeleteUrl
        {
            get
            {
                return SitkaRoute<ProjectNoteUpdateController>.BuildUrlFromExpression(x =>
                    x.Delete(ProjectDocumentUpdateID));
            }
        }
        public string EditUrl {
            get
            {
                return SitkaRoute<ProjectNoteUpdateController>.BuildUrlFromExpression(x =>
                    x.Edit(ProjectDocumentUpdateID));
            }
        }
        public string DisplayCssClass { get; set; }
    }
}