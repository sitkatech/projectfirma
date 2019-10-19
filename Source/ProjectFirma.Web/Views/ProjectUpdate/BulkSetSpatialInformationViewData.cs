using System.Collections.Generic;
using ProjectFirma.Web.Views.Shared.ProjectGeospatialAreaControls;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class BulkSetSpatialInformationViewData : ProjectUpdateViewData
    {
        public BulkSetProjectSpatialInformationViewData BulkSetProjectSpatialInformationViewData { get; set; }

        public BulkSetSpatialInformationViewData(Person currentPerson, ProjectUpdateBatch projectUpdateBatch, ProjectUpdateStatus projectUpdateStatus, BulkSetProjectSpatialInformationViewData quickSetViewData) : base(currentPerson, projectUpdateBatch, projectUpdateStatus, new List<string>(), ProjectUpdateSection.BulkSetSpatialInformation.ProjectUpdateSectionDisplayName)
        {
            BulkSetProjectSpatialInformationViewData = quickSetViewData;
        }
    }
}
