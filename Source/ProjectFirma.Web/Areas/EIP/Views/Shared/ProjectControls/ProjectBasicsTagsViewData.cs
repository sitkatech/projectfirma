using ProjectFirma.Web.Areas.EIP.Views.Tag;

namespace ProjectFirma.Web.Areas.EIP.Views.Shared.ProjectControls
{
    public class ProjectBasicsTagsViewData
    {
        public readonly Models.Project Project;
        public readonly TagHelper TagHelper;

        public ProjectBasicsTagsViewData(Models.Project project, TagHelper tagHelper)
        {
            Project = project;
            TagHelper = tagHelper;
        }
    }
}