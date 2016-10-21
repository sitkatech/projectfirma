using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Areas.EIP.Views.ProjectExternalLink
{
    public class EditProjectExternalLinksViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly int ProjectID;

        public EditProjectExternalLinksViewData(Models.Project project)
        {
            ProjectID = project.ProjectID;
        }
    }
}