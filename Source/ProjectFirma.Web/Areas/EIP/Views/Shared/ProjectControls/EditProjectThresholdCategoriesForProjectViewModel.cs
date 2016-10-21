using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Areas.EIP.Views.Shared.ProjectControls
{
    public class EditProjectThresholdCategoriesForProjectViewModel : FormViewModel, IValidatableObject
    {
        public List<ProjectThresholdCategorySimple> ProjectThresholdCategorySimples { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditProjectThresholdCategoriesForProjectViewModel()
        {            
        }
        
        public EditProjectThresholdCategoriesForProjectViewModel(List<ProjectThresholdCategorySimple> projectThresholdCategorySimples)
        {
            ProjectThresholdCategorySimples = projectThresholdCategorySimples;
        }

        public void UpdateModel(Models.Project project, List<ProjectThresholdCategorySimple> projectThresholdCategorySimples)
        {
            foreach (var projectThresholdCategorySimple in projectThresholdCategorySimples)
            {
                var alreadySelected = project.ProjectThresholdCategories
                    .SingleOrDefault(x => x.ThresholdCategoryID == projectThresholdCategorySimple.ThresholdCategoryID) != null;

                if (projectThresholdCategorySimple.Selected && !alreadySelected)
                {
                    var projectThresholdCategory = new ProjectThresholdCategory(project.ProjectID,
                        projectThresholdCategorySimple.ThresholdCategoryID)
                    {
                        ProjectThresholdCategoryNotes = projectThresholdCategorySimple.ProjectThresholdCategoryNotes
                    };

                    project.ProjectThresholdCategories.Add(projectThresholdCategory);
                }
                else if (projectThresholdCategorySimple.Selected && alreadySelected)
                {
                    var existingProjectThresholdCategory = project.ProjectThresholdCategories.First(x => x.ThresholdCategoryID == projectThresholdCategorySimple.ThresholdCategoryID);
                    existingProjectThresholdCategory.ProjectThresholdCategoryNotes = projectThresholdCategorySimple.ProjectThresholdCategoryNotes;
                }
                else if (!projectThresholdCategorySimple.Selected && alreadySelected)
                {
                    var existingProjectThresholdCategory = project.ProjectThresholdCategories.First(x => x.ThresholdCategoryID == projectThresholdCategorySimple.ThresholdCategoryID);

                    HttpRequestStorage.DatabaseEntities.ProjectThresholdCategories.Remove(existingProjectThresholdCategory);
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

            if (!ProjectThresholdCategorySimples.Any(x => x.Selected))
            {
                validationResults.Add(new ValidationResult("You must select at least one Threshold Category."));
            }

            var thresholdCategories = HttpRequestStorage.DatabaseEntities.ThresholdCategories.ToList();
            foreach (var projectThresholdCategorySimple in ProjectThresholdCategorySimples)
            {
                if (projectThresholdCategorySimple.Selected && string.IsNullOrWhiteSpace(projectThresholdCategorySimple.ProjectThresholdCategoryNotes))
                {
                    var thresholdCategoryName = thresholdCategories.Single(x => x.ThresholdCategoryID == projectThresholdCategorySimple.ThresholdCategoryID).DisplayName;
                    validationResults.Add(new ValidationResult(String.Format("You must include notes for {0}", thresholdCategoryName)));
                }
            }
            return validationResults;
        }
    }
}