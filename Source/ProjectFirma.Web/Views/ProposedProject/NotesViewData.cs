using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared.TextControls;

namespace ProjectFirma.Web.Views.ProposedProject
{
    public class NotesViewData : ProposedProjectViewData
    {
        public readonly EntityNotesViewData EntityNotesViewData;

        public NotesViewData(Person currentPerson,
            Models.ProposedProject proposedProject,
            ProposalSectionsStatus proposalSectionsStatus,
            EntityNotesViewData entityNotesViewData) : base(currentPerson, proposedProject, ProposedProjectSectionEnum.Notes, proposalSectionsStatus)
        {
            EntityNotesViewData = entityNotesViewData;            
        }
    }
}