using System.Collections.Generic;
using ProjectFirma.Web.Views.Shared.ProjectPotentialPartner;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class PartnerFinderProjectUpdateViewData : ProjectUpdateViewData
    {
        // Potential Match Maker Project Partners (if any)
        public ProjectPotentialPartnerDetailViewData ProjectPotentialPartnerDetailViewData;

        public PartnerFinderProjectUpdateViewData(FirmaSession currentFirmaSession, ProjectUpdateBatch projectUpdateBatch, ProjectUpdateStatus projectUpdateStatus) :
            base(currentFirmaSession, projectUpdateBatch, projectUpdateStatus, new List<string>(), ProjectUpdateSection.PartnerFinder.ProjectUpdateSectionDisplayName)
        {
            // Our component's view data
            ProjectPotentialPartnerDetailViewData = new ProjectPotentialPartnerDetailViewData(CurrentFirmaSession, projectUpdateBatch.Project, ProjectPotentialPartnerListDisplayMode.ProjectDetailViewPartialList);
        }
    }
}
