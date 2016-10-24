using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Views.Shared.ProjectLocationControls
{
    public class ProjectLocationSummaryViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly string ProjectLocationNotes;
        public readonly ProjectLocationSummaryMapInitJson ProjectLocationSummaryMapInitJson;

        public ProjectLocationSummaryViewData(IProject project, ProjectLocationSummaryMapInitJson projectLocationSummaryMapInitJson)
        {
            ProjectLocationNotes = project.ProjectLocationNotes;
            ProjectLocationSummaryMapInitJson = projectLocationSummaryMapInitJson;
        }
    }
}