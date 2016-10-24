using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Map;

namespace ProjectFirma.Web.Views.Shared.ProjectLocationControls
{
    public class ApproveGisUploadViewData
    {
        public readonly List<IProjectLocationStaging> ProjectLocationStagings;
        public readonly string ApproveGisUploadUrl;
        public readonly MapInitJson MapInitJson;
        public readonly string MapFormID;

        public ApproveGisUploadViewData(List<IProjectLocationStaging> projectLocationStagings, MapInitJson mapInitJson, string mapFormID, string approveGisUploadUrl)
        {
            ProjectLocationStagings = projectLocationStagings;
            MapInitJson = mapInitJson;
            MapFormID = mapFormID;
            ApproveGisUploadUrl = approveGisUploadUrl;
        }
    }
}