namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public abstract class SiteLayout : LtInfo.Common.Mvc.TypedWebViewPage<ProjectUpdateViewData>
    {
        protected string SetSelectedSectionStyle(ProjectUpdateSectionEnum currentSection, ProjectUpdateSectionEnum selectedProjectUpdateSection)
        {
            return selectedProjectUpdateSection == currentSection ? "selected" : "selectable";
        }
    }
}