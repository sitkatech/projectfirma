using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ClassificationSystemModelExtensions
    {
        public static string GetEditProjectClassificationsUrl(this ClassificationSystem classificationSystem, Project project)
        {
            return SitkaRoute<ProjectClassificationController>.BuildUrlFromExpression(t => t.EditProjectClassificationsForProject(project, classificationSystem));
        }

        public static string GetContentUrl(ClassificationSystem classificationSystem)
        {
            return SitkaRoute<FieldDefinitionController>.BuildUrlFromExpression(x =>
                x.FieldDefinitionDetailsForClassificationSystem(classificationSystem.ClassificationSystemID));
        }
    }
}