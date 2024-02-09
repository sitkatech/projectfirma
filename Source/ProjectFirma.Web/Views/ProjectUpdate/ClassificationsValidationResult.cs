using System.Collections.Generic;
using System.Linq;
using MoreLinq;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class ClassificationsValidationResult
    {
        private readonly List<string> _warningMessages;

        public ClassificationsValidationResult()
        {
            _warningMessages = new List<string>();
        }


        public ClassificationsValidationResult(List<ProjectClassificationSimple> projectClassificationSimple, string classificationFieldDefinitionLabel, string classificationSystemFieldDefinitionLabel, int classificationSystemID)
        {
            _warningMessages = new List<string>();


            if (classificationSystem.IsRequired && !projectClassificationSimple.Any())
            {
                _warningMessages.Add($"You must select at least one {classificationFieldDefinitionLabel} per {classificationSystemFieldDefinitionLabel}");
            }

            var classificationSystem = HttpRequestStorage.DatabaseEntities.ClassificationSystems.GetClassificationSystem(classificationSystemID);
            var selectedClassifications = projectClassificationSimple.Where(x => x.ClassificationSystemID == classificationSystemID && x.Selected);
            if (classificationSystem.IsRequired && !selectedClassifications.Any())
            {
                _warningMessages.Add(
                    $"You must select at least one {classificationSystem.ClassificationSystemName}");
            }
        }

        public List<string> GetWarningMessages()
        {
            return _warningMessages;
        }

        public bool IsValid => !_warningMessages.Any();
    }
}