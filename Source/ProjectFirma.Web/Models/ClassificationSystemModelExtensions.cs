﻿using ProjectFirma.Web.Common;
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

        public static string GetContentUrl(this ClassificationSystem classificationSystem)
        {
            return SitkaRoute<FieldDefinitionController>.BuildUrlFromExpression(x =>
                x.FieldDefinitionDetailsForClassificationSystem(classificationSystem.ClassificationSystemID));
        }

        public static string GetClassificationSystemNamePluralized(ClassificationSystem classificationSystem)
        {
            if (!string.IsNullOrEmpty(classificationSystem.ClassificationSystemNamePlural))
            {
                return classificationSystem.ClassificationSystemNamePlural;
            }

            return FieldDefinitionModelExtensions.PluralizationService.Pluralize(classificationSystem.ClassificationSystemName);
        }
           
    }
}