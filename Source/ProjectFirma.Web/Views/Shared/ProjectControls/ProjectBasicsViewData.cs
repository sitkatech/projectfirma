namespace ProjectFirma.Web.Views.Shared.ProjectControls
{
    public class ProjectBasicsViewData
    {
        public readonly Models.Project Project;
        public readonly bool UserHasProjectBudgetManagePermissions;
        public readonly bool UserHasTaggingPermissions;
        public readonly ProjectBasicsCalculatedCostsViewData ProjectBasicsCalculatedCostsViewData;
        public readonly ProjectBasicsTagsViewData ProjectBasicsTagsViewData;
        public readonly bool ShowFactSheetIcon;

        public ProjectBasicsViewData(Models.Project project, bool userHasProjectBudgetManagePermissions, bool userHasTaggingPermissions, bool showFactSheetIcon, ProjectBasicsCalculatedCostsViewData projectBasicsCalculatedCostsViewData, ProjectBasicsTagsViewData projectBasicsTagsViewData)
        {
            Project = project;
            UserHasProjectBudgetManagePermissions = userHasProjectBudgetManagePermissions;
            UserHasTaggingPermissions = userHasTaggingPermissions;
            ProjectBasicsCalculatedCostsViewData = projectBasicsCalculatedCostsViewData;
            ProjectBasicsTagsViewData = projectBasicsTagsViewData;
            ShowFactSheetIcon = showFactSheetIcon;
        }
    }
}