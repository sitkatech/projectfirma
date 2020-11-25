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


        public ClassificationsValidationResult(List<ProjectClassificationSimple> projectClassificationSimple, string classificationFieldDefinitionLabel, string classificationSystemFieldDefinitionLabel)
        {
            _warningMessages = new List<string>();


            if (!projectClassificationSimple.Any())
            {
                _warningMessages.Add($"You must select at least one {classificationFieldDefinitionLabel} per {classificationSystemFieldDefinitionLabel}");
            }

            projectClassificationSimple.Select(x => x.ClassificationSystemID).Distinct().ForEach(s =>
            {
                var classificationSystem =
                    HttpRequestStorage.DatabaseEntities.ClassificationSystems.GetClassificationSystem(s);
                var selectedClassifications = projectClassificationSimple.Where(x => x.ClassificationSystemID == s && x.Selected);
                if (!selectedClassifications.Any())
                {
                    _warningMessages.Add(
                        $"You must select at least one {classificationSystem.ClassificationSystemName}");
                }
            });
        }

        public List<string> GetWarningMessages()
        {
            return _warningMessages;
        }

        public bool IsValid => !_warningMessages.Any();
    }
}