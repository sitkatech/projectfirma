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
        Classifications,
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
        public bool IsClassificationsComplete { get; set; }
        public bool IsAssessmentComplete { get; set; }
        public bool IsNotesSectionComplete { get; set; }
        public bool AreAllSectionsValid
        {
            get
            {
                return IsBasicsSectionComplete && IsPerformanceMeasureSectionComplete && IsClassificationsComplete && IsAssessmentComplete && IsProjectLocationSimpleSectionComplete && IsProjectLocationSimpleSectionComplete && IsNotesSectionComplete;
            }
        }

        public ProposalSectionsStatus(Models.ProposedProject proposedProject)
        {
            var basicsResults = new BasicsViewModel(proposedProject).GetValidationResults();
            IsBasicsSectionComplete = !basicsResults.Any();

            var locationSimpleValidationResults = new LocationSimpleViewModel(proposedProject).GetValidationResults();
            IsProjectLocationSimpleSectionComplete = !locationSimpleValidationResults.Any();

            IsProjectLocationDetailedSectionComplete = IsBasicsSectionComplete;

            var pmValidationResults = new ExpectedPerformanceMeasureValuesViewModel(proposedProject).GetValidationResults();
            IsPerformanceMeasureSectionComplete = !pmValidationResults.Any();

            var proposedProjectClassificationSimples = ProposedProjectController.GetProposedProjectClassificationSimples(proposedProject);
            var classificationValidationResults = new EditProposedProjectClassificationsViewModel(proposedProjectClassificationSimples).GetValidationResults();
            IsClassificationsComplete = !classificationValidationResults.Any();

            IsAssessmentComplete = ProposedProjectController.GetProposedProjectAssessmentQuestionSimples(proposedProject).All(simple => simple.Answer.HasValue);

            IsNotesSectionComplete = IsBasicsSectionComplete; //there is no validation required on Notes
        }

        public ProposalSectionsStatus()
        {
            IsBasicsSectionComplete = false;
            IsPerformanceMeasureSectionComplete = false;
            IsClassificationsComplete = false;
            IsAssessmentComplete = false;
            IsProjectLocationSimpleSectionComplete = false;
            IsProjectLocationDetailedSectionComplete = false;
            IsNotesSectionComplete = false;
        }
    }
}