using ProjectFirma.Web.Views.Shared.ProjectGeospatialAreaControls;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class BulkSetSpatialInformationViewData : ProjectCreateViewData
    {
        public BulkSetProjectSpatialInformationViewData BulkSetProjectSpatialInformationViewData { get; set; }

        public BulkSetSpatialInformationViewData(Person currentPerson, ProjectFirmaModels.Models.Project project, ProposalSectionsStatus proposalSectionStatus, BulkSetProjectSpatialInformationViewData quickSetViewData) : base(currentPerson, project, ProjectCreateSection.BulkSetSpatialInformation.ProjectCreateSectionDisplayName, proposalSectionStatus)
        {
            BulkSetProjectSpatialInformationViewData = quickSetViewData;
        }

        
    }
}
