using System.Collections.Generic;
using ProjectFirma.Web.Views.Shared.ProjectGeospatialAreaControls;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class BulkSetSpatialInformationViewData : ProjectUpdateViewData
    {
        public BulkSetProjectSpatialInformationViewData BulkSetProjectSpatialInformationViewData { get; set; }

        public BulkSetSpatialInformationViewData(FirmaSession currentFirmaSession, ProjectUpdateBatch projectUpdateBatch, ProjectUpdateStatus projectUpdateStatus, BulkSetProjectSpatialInformationViewData quickSetViewData) : base(currentFirmaSession, projectUpdateBatch, projectUpdateStatus, new List<string>(), ProjectUpdateSection.BulkSetSpatialInformation.ProjectUpdateSectionDisplayName)
        {
            BulkSetProjectSpatialInformationViewData = quickSetViewData;
        }
    }
}
