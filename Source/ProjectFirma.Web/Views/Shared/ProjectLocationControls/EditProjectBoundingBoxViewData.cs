using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectLocationControls
{
    public class EditProjectBoundingBoxViewData
    {
        public MapInitJson MapInitJson { get; }
        public string EditProjectBoundingBoxUrl { get; }
        public string EditProjectBoundingBoxFormID { get; }

        public EditProjectBoundingBoxViewData(MapInitJson mapInitJson, string editProjectBoundingBoxUrl,
            string editProjectBoundingBoxFormID)
        {
            MapInitJson = mapInitJson;
            EditProjectBoundingBoxUrl = editProjectBoundingBoxUrl;
            EditProjectBoundingBoxFormID = editProjectBoundingBoxFormID;
        }
    }
}
