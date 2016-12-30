using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.ProjectUpdate;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared.ExpenditureAndBudgetControls;
using ProjectFirma.Web.Views.Shared.ProjectControls;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.TextControls;
using LtInfo.Common;
using ProjectFirma.Web.Views.Shared.PerformanceMeasureControls;
using ProjectFirma.Web.Views.Tag;

namespace ProjectFirma.Web.Views.Project
{
    public class SummaryViewData : ProjectViewData
    {
        public readonly bool UserHasProjectViewEverythingPermissions;
        public readonly bool UserHasEditProjectPermissions;
        public readonly bool UserHasProjectUpdatePermissions;
        public readonly bool UserHasProjectOrganizationManagePermissions;
        public readonly bool UserHasProjectClassificationManagePermissions;
        public readonly bool UserHasProjectWatershedManagePermissions;
        public readonly bool UserHasMapManagePermissions;
        public readonly bool UserHasPerformanceMeasureExpectedViewPermissions;
        public readonly bool UserHasPerformanceMeasureExpectedManagePermissions;
        public readonly bool UserHasPerformanceMeasureActualManagePermissions;
        public readonly bool UserHasProjectFundingSourceExpenditureManagePermissions;
        public readonly bool UserHasProjectBudgetManagePermissions;
        public readonly bool UserHasProjectExternalLinkManagePermissions;

        public readonly string EditProjectUrl;
        public readonly string EditProjectOrganizationsUrl;
        public readonly string EditClassificationsUrl;
        public readonly string EditWatershedsUrl;
        public readonly string EditSimpleProjectLocationUrl;
        public readonly string EditDetailedProjectLocationUrl;
        public readonly string EditPerformanceMeasureExpectedsUrl;
        public readonly string EditPerformanceMeasureActualsUrl;
        public readonly string EditReportedExpendituresUrl;
        public readonly string EditProjectBudgetUrl;
        public readonly string EditExternalLinksUrl;
        public readonly string ConfirmNonMandatoryUpdateUrl;
        public readonly string EditAssessmentUrl;
        
        public readonly ProjectTaxonomyViewData ProjectTaxonomyViewData;
        public readonly ProjectBudgetSummaryViewData ProjectBudgetSummaryViewData;
        public readonly ProjectBasicsViewData ProjectBasicsViewData;
        public readonly ProjectLocationSummaryViewData ProjectLocationSummaryViewData;
        public readonly PerformanceMeasureExpectedSummaryViewData PerformanceMeasureExpectedSummaryViewData;
        public readonly PerformanceMeasureReportedValuesGroupedViewData PerformanceMeasureReportedValuesGroupedViewData;
        public readonly ProjectExpendituresSummaryViewData ProjectExpendituresSummaryViewData;
        public readonly ImageGalleryViewData ImageGalleryViewData;
        public readonly EntityNotesViewData EntityNotesViewData;
        public readonly EntityExternalLinksViewData EntityExternalLinksViewData;

        public readonly bool UserHasTaggingPermissions;
        public readonly ProjectBasicsTagsViewData ProjectBasicsTagsViewData;

        public readonly List<ProjectStage> ProjectStages;
        public readonly List<ProjectImplementingOrganizationOrProjectFundingOrganization> AllProjectOrganizations;
        public readonly string MapFormID;

        public readonly ProjectUpdateBatchGridSpec ProjectUpdateBatchGridSpec;
        public readonly string ProjectUpdateBatchGridName;
        public readonly string ProjectUpdateBatchGridDataUrl;
        
        public readonly AuditLogsGridSpec AuditLogsGridSpec;
        public readonly string AuditLogsGridName;
        public readonly string AuditLogsGridDataUrl;

        public readonly ProjectNotificationGridSpec ProjectNotificationGridSpec;
        public readonly string ProjectNotificationGridName;
        public readonly string ProjectNotificationGridDataUrl;

        public readonly AssessmentTreeViewData AssessmentTreeViewData;

        //TODO: Inline all url parameters
        public SummaryViewData(Person currentPerson, Models.Project project, string confirmNonMandatoryUpdateUrl, List<ProjectStage> projectStages, ProjectTaxonomyViewData projectTaxonomyViewData,
            ProjectBudgetSummaryViewData projectBudgetSummaryViewData, 
            ProjectLocationSummaryViewData projectLocationSummaryViewData, string mapFormID, string editSimpleProjectLocationUrl, string editDetailedProjectLocationUrl,
            string editProjectOrganizationsUrl, PerformanceMeasureExpectedSummaryViewData performanceMeasureExpectedSummaryViewData, string editPerformanceMeasureExpectedsUrl,
            PerformanceMeasureReportedValuesGroupedViewData performanceMeasureReportedValuesGroupedViewData, string editPerformanceMeasureActualsUrl,
            ProjectExpendituresSummaryViewData projectExpendituresSummaryViewData, string editReportedExpendituresUrl, 
            string editClassificationsUrl, string editAssessmentUrl, string editWatershedsUrl, ImageGalleryViewData imageGalleryViewData, 
            EntityNotesViewData entityNotesViewData, 
            AuditLogsGridSpec auditLogsGridSpec, string auditLogsGridDataUrl,
            string editProjectBudgetUrl, string editExternalLinksUrl, EntityExternalLinksViewData entityExternalLinksViewData, ProjectNotificationGridSpec projectNotificationGridSpec, string projectNotificationGridName, string projectNotificationGridDataUrl, ProjectBasicsViewData projectBasicsViewData, AssessmentTreeViewData assessmentTreeViewData) 
            : base(currentPerson, project)
        {
            PageTitle = project.DisplayName.ToEllipsifiedStringClean(110);
            BreadCrumbTitle = "Project Summary";

            ConfirmNonMandatoryUpdateUrl = confirmNonMandatoryUpdateUrl;
            ProjectStages = projectStages;

            EditProjectUrl = project.GetEditUrl();
            UserHasProjectViewEverythingPermissions = new AdminFeature().HasPermissionByPerson(currentPerson);
            UserHasEditProjectPermissions = new ProjectEditFeature().HasPermission(currentPerson, project).HasPermission;
            UserHasProjectUpdatePermissions = new ProjectUpdateManageFeature().HasPermission(CurrentPerson, project).HasPermission;
            ProjectBasicsViewData = projectBasicsViewData;
            AssessmentTreeViewData = assessmentTreeViewData;

            UserHasTaggingPermissions = new TagManageFeature().HasPermissionByPerson(CurrentPerson);
            var tagHelper = new TagHelper(project.ProjectTags.Select(x => new BootstrapTag(x.Tag)).ToList());
            ProjectBasicsTagsViewData = new ProjectBasicsTagsViewData(project, tagHelper);

            ProjectTaxonomyViewData = projectTaxonomyViewData;

            ProjectBudgetSummaryViewData = projectBudgetSummaryViewData;
            UserHasProjectBudgetManagePermissions = new ProjectBudgetManageFeature().HasPermissionByPerson(currentPerson);

            ProjectLocationSummaryViewData = projectLocationSummaryViewData;
            MapFormID = mapFormID;
            EditSimpleProjectLocationUrl = editSimpleProjectLocationUrl;
            EditDetailedProjectLocationUrl = editDetailedProjectLocationUrl;
            UserHasMapManagePermissions = new ProjectMapManageFeature().HasPermissionByPerson(currentPerson);

            AllProjectOrganizations = project.GetAllProjectOrganizations();
            EditProjectOrganizationsUrl = editProjectOrganizationsUrl;
            UserHasProjectOrganizationManagePermissions = new ProjectOrganizationManageFeature().HasPermissionByPerson(currentPerson);

            PerformanceMeasureExpectedSummaryViewData = performanceMeasureExpectedSummaryViewData;
            EditPerformanceMeasureExpectedsUrl = editPerformanceMeasureExpectedsUrl;
            UserHasPerformanceMeasureExpectedManagePermissions = new PerformanceMeasureExpectedFromProjectManageFeature().HasPermission(currentPerson, project).HasPermission;
            UserHasPerformanceMeasureExpectedViewPermissions = new PerformanceMeasureExpectedFromProjectViewFeature().HasPermission(currentPerson, project).HasPermission;

            PerformanceMeasureReportedValuesGroupedViewData = performanceMeasureReportedValuesGroupedViewData;
            EditPerformanceMeasureActualsUrl = editPerformanceMeasureActualsUrl;
            UserHasPerformanceMeasureActualManagePermissions = new PerformanceMeasureActualFromProjectManageFeature().HasPermission(currentPerson, project).HasPermission;

            ProjectExpendituresSummaryViewData = projectExpendituresSummaryViewData;
            EditReportedExpendituresUrl = editReportedExpendituresUrl;
            UserHasProjectFundingSourceExpenditureManagePermissions = new ProjectFundingSourceExpenditureFromProjectManageFeature().HasPermission(currentPerson, project).HasPermission;

            EditClassificationsUrl = editClassificationsUrl;
            UserHasProjectClassificationManagePermissions = new ProjectEditFeature().HasPermissionByPerson(currentPerson);

            EditAssessmentUrl = editAssessmentUrl;

            EditWatershedsUrl = editWatershedsUrl;
            UserHasProjectWatershedManagePermissions = new ProjectWatershedManageFromProjectFeature().HasPermissionByPerson(currentPerson);

            EditExternalLinksUrl = editExternalLinksUrl;
            EntityExternalLinksViewData = entityExternalLinksViewData;
            UserHasProjectExternalLinkManagePermissions = new ProjectExternalLinkManageFeature().HasPermissionByPerson(currentPerson);

            ImageGalleryViewData = imageGalleryViewData;

            EntityNotesViewData = entityNotesViewData;

            ProjectUpdateBatchGridSpec = new ProjectUpdateBatchGridSpec() { ObjectNameSingular = "Project Update", ObjectNamePlural = "Project Updates", SaveFiltersInCookie = true };
            ProjectUpdateBatchGridName = "projectUpdateBatch";
            ProjectUpdateBatchGridDataUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(x => x.ProjectUpdateBatchGridJsonData(project.ProjectID));

            AuditLogsGridSpec = auditLogsGridSpec;
            AuditLogsGridName = "projectAuditLogsGrid";
            AuditLogsGridDataUrl = auditLogsGridDataUrl;

            EditProjectBudgetUrl = editProjectBudgetUrl;

            ProjectNotificationGridSpec = projectNotificationGridSpec;
            ProjectNotificationGridName = projectNotificationGridName;
            ProjectNotificationGridDataUrl = projectNotificationGridDataUrl;
        }
    }
}
