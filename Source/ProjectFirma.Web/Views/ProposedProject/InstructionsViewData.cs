using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ProposedProject
{
    public class InstructionsViewData : ProposedProjectViewData
    {
        public InstructionsViewData(Person currentPerson) : base(currentPerson, ProposedProjectSectionEnum.Instructions)
        {
        }

        public InstructionsViewData(Person currentPerson, Models.ProposedProject proposedProject, ProposalSectionsStatus proposalSectionsStatus) : base(currentPerson, proposedProject, ProposedProjectSectionEnum.Instructions, proposalSectionsStatus)
        {
        }
    }
}