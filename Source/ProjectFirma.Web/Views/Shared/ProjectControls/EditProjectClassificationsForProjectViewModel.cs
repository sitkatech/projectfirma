using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectControls
{
    public class EditProjectClassificationsForProjectViewModel : FormViewModel, IValidatableObject
    {
        public List<ProjectClassificationSimple> ProjectClassificationSimples { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditProjectClassificationsForProjectViewModel()
        {            
        }
        
        public EditProjectClassificationsForProjectViewModel(List<ProjectClassificationSimple> projectClassificationSimples)
        {
            ProjectClassificationSimples = projectClassificationSimples;
        }

        public void UpdateModel(Models.Project project, List<ProjectClassificationSimple> projectClassificationSimples)
        {
            foreach (var projectClassificationSimple in projectClassificationSimples)
            {
                var alreadySelected = project.ProjectClassifications
                    .SingleOrDefault(x => x.ClassificationID == projectClassificationSimple.ClassificationID) != null;

                if (projectClassificationSimple.Selected && !alreadySelected)
                {
                    var projectClassification = new ProjectClassification(project.ProjectID,
                        projectClassificationSimple.ClassificationID)
                    {
                        ProjectClassificationNotes = projectClassificationSimple.ProjectClassificationNotes
                    };

                    project.ProjectClassifications.Add(projectClassification);
                }
                else if (projectClassificationSimple.Selected && alreadySelected)
                {
                    var existingProjectClassification = project.ProjectClassifications.First(x => x.ClassificationID == projectClassificationSimple.ClassificationID);
                    existingProjectClassification.ProjectClassificationNotes = projectClassificationSimple.ProjectClassificationNotes;
                }
                else if (!projectClassificationSimple.Selected && alreadySelected)
                {
                    var existingProjectClassification = project.ProjectClassifications.First(x => x.ClassificationID == projectClassificationSimple.ClassificationID);

                    HttpRequestStorage.DatabaseEntities.ProjectClassifications.Remove(existingProjectClassification);
                }
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return GetValidationResults();
        }

        public IEnumerable<ValidationResult> GetValidationResults()
        {
            var validationResults = new List<ValidationResult>();

            if (!ProjectClassificationSimples.Any(x => x.Selected))
            {
                validationResults.Add(new ValidationResult(string.Format("You must select at least one {0}.", MultiTenantHelpers.GetClassificationDisplayName())));
            }

            var classifications = HttpRequestStorage.DatabaseEntities.Classifications.ToList();
            foreach (var projectClassificationSimple in ProjectClassificationSimples)
            {
                if (projectClassificationSimple.Selected && string.IsNullOrWhiteSpace(projectClassificationSimple.ProjectClassificationNotes))
                {
                    var classificationName = classifications.Single(x => x.ClassificationID == projectClassificationSimple.ClassificationID).DisplayName;
                    validationResults.Add(new ValidationResult(String.Format("You must include notes for {0}", classificationName)));
                }
            }
            return validationResults;
        }
    }
}