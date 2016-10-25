using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Views.ProjectExternalLink
{
    public class EditProjectExternalLinksViewData : FirmaUserControlViewData
    {
        public readonly int ProjectID;

        public EditProjectExternalLinksViewData(Models.Project project)
        {
            ProjectID = project.ProjectID;
        }
    }
}