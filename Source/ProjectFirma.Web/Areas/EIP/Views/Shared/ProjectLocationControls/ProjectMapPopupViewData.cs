using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Areas.EIP.Views.Shared.ProjectLocationControls
{
    public class ProjectMapPopupViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly Models.Project Project;

        public ProjectMapPopupViewData(Models.Project project)
        {
            Project = project;
        }
    }
}