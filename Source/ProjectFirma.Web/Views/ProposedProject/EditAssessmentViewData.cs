using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ProposedProject
{
    public class EditAssessmentViewData : ProposedProjectViewData
    {
        public readonly List<AssessmentGoal> AssessmentGoals;
        public readonly string ProjectName;

        public EditAssessmentViewData(Person currentPerson, Models.ProposedProject proposedProject, List<AssessmentGoal> assessmentGoals, ProposedProjectSectionEnum proposedProjectSection, ProposalSectionsStatus proposalSectionsStatus)
            : base(currentPerson, proposedProject, proposedProjectSection, proposalSectionsStatus)
        {
            ProjectName = proposedProject.DisplayName;
            AssessmentGoals = assessmentGoals;
        }
    }
}