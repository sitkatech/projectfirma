using ProjectFirma.Web.Views.Shared.ProjectPotentialPartner;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class PartnerFinderProjectCreateViewData : ProjectCreateViewData
    {
        // Potential Match Maker Project Partners (if any)
        public ProjectPotentialPartnerDetailViewData ProjectPotentialPartnerDetailViewData;

        public PartnerFinderProjectCreateViewData(FirmaSession currentFirmaSession,
                                                  ProjectFirmaModels.Models.Project project,
                                                  ProposalSectionsStatus proposalSectionStatus
            )
            : base(currentFirmaSession,
                   project,
                   ProjectCreateSection.PartnerFinder.ProjectCreateSectionDisplayName,
                   proposalSectionStatus)
        {
            // Our component's view data
            ProjectPotentialPartnerDetailViewData = new ProjectPotentialPartnerDetailViewData(CurrentFirmaSession, project, ProjectPotentialPartnerListDisplayMode.ProjectDetailViewPartialList);
        }
    }
}
