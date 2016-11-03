using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Controllers;

namespace ProjectFirma.Web.Views.ProposedProject
{
    public enum ProposedProjectSectionEnum
    {
        Instructions,
        Basics,
        PerformanceMeasures,
        LocationSimple,
        LocationDetailed,
        ThresholdCategories,
        Assessment,
        Notes,
        History,
        Photos
    }

    public class ProposalSectionsStatus
    {
        public bool IsBasicsSectionComplete { get; set; }
        public bool IsPerformanceMeasureSectionComplete { get; set; }
        public bool IsProjectLocationSimpleSectionComplete { get; set; }
        public bool IsProjectLocationDetailedSectionComplete { get; set; }
        public bool IsThresholdCategoriesComplete { get; set; }
        public bool IsAssessmentComplete { get; set; }
        public bool IsNotesSectionComplete { get; set; }
        public bool AreAllSectionsValid
        {
            get
            {
                return IsBasicsSectionComplete && IsPerformanceMeasureSectionComplete && IsThresholdCategoriesComplete && IsAssessmentComplete && IsProjectLocationSimpleSectionComplete && IsProjectLocationSimpleSectionComplete && IsNotesSectionComplete;
            }
        }

        public ProposalSectionsStatus(Models.ProposedProject proposedProject)
        {
            var basicsValidator = new BasicsViewModelValidator(new List<Models.ProposedProject> { proposedProject });
            var validationResult = basicsValidator.Validate(new BasicsViewModel(proposedProject));
            IsBasicsSectionComplete = validationResult.IsValid;

            var locationSimpleValidationResults = new LocationSimpleViewModel(proposedProject).GetValidationResults();
            IsProjectLocationSimpleSectionComplete = !locationSimpleValidationResults.Any();

            IsProjectLocationDetailedSectionComplete = IsBasicsSectionComplete;

            var pmValidationResults = new ExpectedPerformanceMeasureValuesViewModel(proposedProject).GetValidationResults();
            IsPerformanceMeasureSectionComplete = !pmValidationResults.Any();

            var proposedProjectThresholdCategorySimples = ProposedProjectController.GetProposedProjectThresholdCategorySimples(proposedProject);
            var thresholdValidationResults = new EditProposedProjectThresholdCategoriesViewModel(proposedProjectThresholdCategorySimples).GetValidationResults();
            IsThresholdCategoriesComplete = !thresholdValidationResults.Any();

            IsAssessmentComplete = ProposedProjectController.GetProposedProjectAssessmentQuestionSimples(proposedProject).All(simple => simple.Answer.HasValue);

            IsNotesSectionComplete = IsBasicsSectionComplete; //there is no validation required on Notes
        }

        public ProposalSectionsStatus()
        {
            IsBasicsSectionComplete = false;
            IsPerformanceMeasureSectionComplete = false;
            IsThresholdCategoriesComplete = false;
            IsAssessmentComplete = false;
            IsProjectLocationSimpleSectionComplete = false;
            IsProjectLocationDetailedSectionComplete = false;
            IsNotesSectionComplete = false;
        }
    }
}