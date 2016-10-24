using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ProposedProject
{
    public class EditTransportationAssessmentViewData : ProposedProjectViewData
    {
        public readonly List<TransportationGoal> TransportationGoals;
        public readonly string ProjectName;
        
        public EditTransportationAssessmentViewData(Person currentPerson, Models.ProposedProject proposedProject, List<TransportationGoal> transportationGoals, ProposedProjectSectionEnum proposedProjectSection, ProposalSectionsStatus proposalSectionsStatus)
            : base(currentPerson, proposedProject, proposedProjectSection, proposalSectionsStatus)
        {
            ProjectName = proposedProject.DisplayName;
            TransportationGoals = transportationGoals;

        }
    }
}