using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Areas.EIP.Views.ProposedProject
{
    public class EditProposedProjectThresholdCategoriesViewModel : FormViewModel, IValidatableObject
    {
        public List<ProposedProjectThresholdCategorySimple> ProposedProjectThresholdCategorySimples { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditProposedProjectThresholdCategoriesViewModel()
        {
        }

        public EditProposedProjectThresholdCategoriesViewModel(List<ProposedProjectThresholdCategorySimple> proposedProjectThresholdCategorySimples)
        {
            ProposedProjectThresholdCategorySimples = proposedProjectThresholdCategorySimples;
        }

        public void UpdateModel(Models.ProposedProject proposedProject, List<ProposedProjectThresholdCategorySimple> proposedProjectThresholdCategorySimples)
        {
            foreach (var proposedProjectThresholdCategorySimple in proposedProjectThresholdCategorySimples)
            {
                var alreadySelected = proposedProject.ProposedProjectThresholdCategories
                    .SingleOrDefault(x => x.ThresholdCategoryID == proposedProjectThresholdCategorySimple.ThresholdCategoryID) != null;

                if (proposedProjectThresholdCategorySimple.Selected && !alreadySelected)
                {
                    var proposedProjectThresholdCategory = new ProposedProjectThresholdCategory(proposedProject.ProposedProjectID,
                        proposedProjectThresholdCategorySimple.ThresholdCategoryID)
                    {
                        ProposedProjectThresholdCategoryNotes = proposedProjectThresholdCategorySimple.ProposedProjectThresholdCategoryNotes
                    };

                    proposedProject.ProposedProjectThresholdCategories.Add(proposedProjectThresholdCategory);
                }
                else if (proposedProjectThresholdCategorySimple.Selected && alreadySelected)
                {
                    var existingProposedProjectThresholdCategory = proposedProject.ProposedProjectThresholdCategories.First(x => x.ThresholdCategoryID == proposedProjectThresholdCategorySimple.ThresholdCategoryID);
                    existingProposedProjectThresholdCategory.ProposedProjectThresholdCategoryNotes = proposedProjectThresholdCategorySimple.ProposedProjectThresholdCategoryNotes;
                }
                else if (!proposedProjectThresholdCategorySimple.Selected && alreadySelected)
                {
                    var existingProposedProjectThresholdCategory = proposedProject.ProposedProjectThresholdCategories.First(x => x.ThresholdCategoryID == proposedProjectThresholdCategorySimple.ThresholdCategoryID);

                    HttpRequestStorage.DatabaseEntities.ProposedProjectThresholdCategories.Remove(existingProposedProjectThresholdCategory);
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

            if (!ProposedProjectThresholdCategorySimples.Any(x => x.Selected))
            {
                validationResults.Add(new ValidationResult("You must select at least one Threshold Category."));
            }

            var thresholdCategories = HttpRequestStorage.DatabaseEntities.ThresholdCategories.ToList();
            foreach (var proposedProjectThresholdCategorySimple in ProposedProjectThresholdCategorySimples)
            {
                if (proposedProjectThresholdCategorySimple.Selected && string.IsNullOrWhiteSpace(proposedProjectThresholdCategorySimple.ProposedProjectThresholdCategoryNotes))
                {
                    var thresholdCategoryName = thresholdCategories.Single(x => x.ThresholdCategoryID == proposedProjectThresholdCategorySimple.ThresholdCategoryID).DisplayName;
                    validationResults.Add(new ValidationResult(String.Format("You must include notes for {0}", thresholdCategoryName)));
                }
            }
            return validationResults;
        }
    }
}