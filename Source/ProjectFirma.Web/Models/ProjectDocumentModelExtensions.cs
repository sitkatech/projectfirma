using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirmaModels.Models
{
    public static class ProjectDocumentModelExtensions
    {
        public static string GetDeleteUrl(this ProjectDocument projectDocument)
        {
            return SitkaRoute<ProjectDocumentController>.BuildUrlFromExpression(x =>
                x.Delete(projectDocument.ProjectDocumentID));
        }

        public static string GetEditUrl(this ProjectDocument projectDocument)
        {
            return SitkaRoute<ProjectDocumentController>.BuildUrlFromExpression(x =>
                x.Edit(projectDocument.ProjectDocumentID));
        }
    }
}