using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Views.Shared.ProjectLocationControls
{
    public class ProjectMapPopupViewData : FirmaUserControlViewData
    {
        public readonly Models.Project Project;

        public ProjectMapPopupViewData(Models.Project project)
        {
            Project = project;
        }
    }
}