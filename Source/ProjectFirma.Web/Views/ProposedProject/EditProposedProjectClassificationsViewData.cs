using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ProposedProject
{
    public class EditProposedProjectClassificationsViewData : ProposedProjectViewData
    {
        public readonly List<Models.Classification> Classifications;
        public readonly string ProjectName;
        
        public EditProposedProjectClassificationsViewData(Person currentPerson, Models.ProposedProject proposedProject, List<Models.Classification> classifications, ProposedProjectSectionEnum proposedProjectSection, ProposalSectionsStatus proposalSectionsStatus)
            : base(currentPerson, proposedProject, proposedProjectSection, proposalSectionsStatus)
        {
            ProjectName = proposedProject.DisplayName;
            Classifications = classifications;
        }
    }
}