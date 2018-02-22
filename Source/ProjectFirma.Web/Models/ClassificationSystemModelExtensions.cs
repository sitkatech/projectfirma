using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirma.Web.Models
{
    public static class ClassificationSystemModelExtensions
    {
        public static string GetEditProjectClassificationsUrl(this ClassificationSystem classificationSystem, Project project)
        {
            return SitkaRoute<ProjectClassificationController>.BuildUrlFromExpression(t => t.EditProjectClassificationsForProject(project, classificationSystem));
        }      
    }
}