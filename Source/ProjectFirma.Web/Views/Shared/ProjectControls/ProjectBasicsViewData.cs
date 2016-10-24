namespace ProjectFirma.Web.Views.Shared.ProjectControls
{
    public class ProjectBasicsViewData
    {
        public readonly Models.Project Project;
        public readonly bool UserHasTransportationProjectBudgetManagePermissions;
        public readonly bool UserHasTaggingPermissions;
        public readonly ProjectBasicsCalculatedCostsViewData ProjectBasicsCalculatedCostsViewData;
        public readonly ProjectBasicsTagsViewData ProjectBasicsTagsViewData;
        public readonly bool ShowFactSheetIcon;

        public ProjectBasicsViewData(Models.Project project, bool userHasTransportationProjectBudgetManagePermissions, bool userHasTaggingPermissions, bool showFactSheetIcon, ProjectBasicsCalculatedCostsViewData projectBasicsCalculatedCostsViewData, ProjectBasicsTagsViewData projectBasicsTagsViewData)
        {
            Project = project;
            UserHasTransportationProjectBudgetManagePermissions = userHasTransportationProjectBudgetManagePermissions;
            UserHasTaggingPermissions = userHasTaggingPermissions;
            ProjectBasicsCalculatedCostsViewData = projectBasicsCalculatedCostsViewData;
            ProjectBasicsTagsViewData = projectBasicsTagsViewData;
            ShowFactSheetIcon = showFactSheetIcon;
        }
    }
}