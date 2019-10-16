using ProjectFirma.Web.Views.Shared.ProjectGeospatialAreaControls;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class QuickSetSpatialInformationViewData : ProjectCreateViewData
    {
        public QuickSetProjectSpatialInformationViewData QuickSetProjectSpatialInformationViewData { get; set; }

        public QuickSetSpatialInformationViewData(Person currentPerson, ProjectFirmaModels.Models.Project project, ProposalSectionsStatus proposalSectionStatus, QuickSetProjectSpatialInformationViewData quickSetViewData) : base(currentPerson, project, ProjectCreateSection.QuickSetSpatialInformation.ProjectCreateSectionDisplayName, proposalSectionStatus)
        {
            QuickSetProjectSpatialInformationViewData = quickSetViewData;
        }

        
    }
}
