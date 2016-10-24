using System.Collections.Generic;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.ProjectUpdate;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared.ExpenditureAndBudgetControls;
using ProjectFirma.Web.Views.Shared.EIPPerformanceMeasureControls;
using ProjectFirma.Web.Views.Shared.ProjectControls;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.TextControls;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Project
{
    public class SummaryViewData : ProjectViewData
    {
        public readonly bool UserHasProjectViewEverythingPermissions;
        public readonly bool UserHasEditProjectPermissions;
        public readonly bool UserHasProjectUpdatePermissions;
        public readonly bool UserHasProjectOrganizationManagePermissions;
        public readonly bool UserHasProjectThresholdCategoryManagePermissions;
        public readonly bool UserHasProjectLocalAndRegionalPlanManagePermissions;
        public readonly bool UserHasProjectWatershedManagePermissions;
        public readonly bool UserHasMapManagePermissions;
        public readonly bool UserHasEIPPerformanceMeasureExpectedViewPermissions;
        public readonly bool UserHasEIPPerformanceMeasureExpectedManagePermissions;
        public readonly bool UserHasEIPPerformanceMeasureActualManagePermissions;
        public readonly bool UserHasProjectFundingSourceExpenditureManagePermissions;
        public readonly bool UserHasTransportationProjectBudgetManagePermissions;
        public readonly bool UserHasProjectExternalLinkManagePermissions;

        public readonly string EditProjectUrl;
        public readonly string EditProjectOrganizationsUrl;
        public readonly string EditThresholdCategoriesUrl;
        public readonly string EditLocalAndRegionalPlansUrl;
        public readonly string EditWatershedsUrl;
        public readonly string EditSimpleProjectLocationUrl;
        public readonly string EditDetailedProjectLocationUrl;
        public readonly string EditEIPPerformanceMeasureExpectedsUrl;
        public readonly string EditEIPPerformanceMeasureActualsUrl;
        public readonly string EditReportedExpendituresUrl;
        public readonly string EditTransportationProjectBudgetUrl;
        public readonly string EditExternalLinksUrl;
        public readonly string ConfirmNonMandatoryUpdateUrl;
        public readonly string EditTransportationAssessmentUrl;
        
        public readonly ProjectTaxonomyViewData ProjectTaxonomyViewData;
        public readonly TransportationProjectBudgetSummaryViewData TransportationProjectBudgetSummaryViewData;
        public readonly ProjectBasicsViewData ProjectBasicsViewData;
        public readonly ProjectLocationSummaryViewData ProjectLocationSummaryViewData;
        public readonly EIPPerformanceMeasureExpectedSummaryViewData EIPPerformanceMeasureExpectedSummaryViewData;
        public readonly EIPPerformanceMeasureReportedValuesGroupedViewData EIPPerformanceMeasureReportedValuesGroupedViewData;
        public readonly ProjectExpendituresSummaryViewData ProjectExpendituresSummaryViewData;
        public readonly ImageGalleryViewData ImageGalleryViewData;
        public readonly EntityNotesViewData EntityNotesViewData;
        public readonly EntityExternalLinksViewData EntityExternalLinksViewData;

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

        public readonly TransportationAssessmentTreeViewData TransportationAssessmentTreeViewData;

        //TODO: Inline all url parameters
        public SummaryViewData(Person currentPerson, Models.Project project, string confirmNonMandatoryUpdateUrl, List<ProjectStage> projectStages, ProjectTaxonomyViewData projectTaxonomyViewData,
            TransportationProjectBudgetSummaryViewData transportationProjectBudgetSummaryViewData, 
            ProjectLocationSummaryViewData projectLocationSummaryViewData, string mapFormID, string editSimpleProjectLocationUrl, string editDetailedProjectLocationUrl,
            string editProjectOrganizationsUrl, EIPPerformanceMeasureExpectedSummaryViewData eipPerformanceMeasureExpectedSummaryViewData, string editEIPPerformanceMeasureExpectedsUrl,
            EIPPerformanceMeasureReportedValuesGroupedViewData eipPerformanceMeasureReportedValuesGroupedViewData, string editEIPPerformanceMeasureActualsUrl,
            ProjectExpendituresSummaryViewData projectExpendituresSummaryViewData, string editReportedExpendituresUrl, 
            string editThresholdCategoriesUrl, string editTransportationAssessmentUrl, string editLocalAndRegionalPlansUrl, string editWatershedsUrl, ImageGalleryViewData imageGalleryViewData, 
            EntityNotesViewData entityNotesViewData, 
            AuditLogsGridSpec auditLogsGridSpec, string auditLogsGridDataUrl,
            string editTransportationProjectBudgetUrl, string editExternalLinksUrl, EntityExternalLinksViewData entityExternalLinksViewData, ProjectNotificationGridSpec projectNotificationGridSpec, string projectNotificationGridName, string projectNotificationGridDataUrl, ProjectBasicsViewData projectBasicsViewData, TransportationAssessmentTreeViewData transportationAssessmentTreeViewData) 
            : base(currentPerson, project)
        {
            PageTitle = project.DisplayName.ToEllipsifiedStringClean(110);
            BreadCrumbTitle = "Project Summary";

            ConfirmNonMandatoryUpdateUrl = confirmNonMandatoryUpdateUrl;
            ProjectStages = projectStages;

            EditProjectUrl = project.GetEditUrl();
            UserHasProjectViewEverythingPermissions = new AdminReadOnlyViewEverythingFeature().HasPermissionByPerson(currentPerson);
            UserHasEditProjectPermissions = new ProjectEditFeature().HasPermission(currentPerson, project).HasPermission;
            UserHasProjectUpdatePermissions = new ProjectUpdateManageFeature().HasPermission(CurrentPerson, project).HasPermission;
            ProjectBasicsViewData = projectBasicsViewData;
            TransportationAssessmentTreeViewData = transportationAssessmentTreeViewData;

            ProjectTaxonomyViewData = projectTaxonomyViewData;

            TransportationProjectBudgetSummaryViewData = transportationProjectBudgetSummaryViewData;
            UserHasTransportationProjectBudgetManagePermissions = new TransportationProjectBudgetManageFeature().HasPermissionByPerson(currentPerson);

            ProjectLocationSummaryViewData = projectLocationSummaryViewData;
            MapFormID = mapFormID;
            EditSimpleProjectLocationUrl = editSimpleProjectLocationUrl;
            EditDetailedProjectLocationUrl = editDetailedProjectLocationUrl;
            UserHasMapManagePermissions = new ProjectMapManageFeature().HasPermissionByPerson(currentPerson);

            AllProjectOrganizations = project.GetAllProjectOrganizations();
            EditProjectOrganizationsUrl = editProjectOrganizationsUrl;
            UserHasProjectOrganizationManagePermissions = new ProjectOrganizationManageFeature().HasPermissionByPerson(currentPerson);

            EIPPerformanceMeasureExpectedSummaryViewData = eipPerformanceMeasureExpectedSummaryViewData;
            EditEIPPerformanceMeasureExpectedsUrl = editEIPPerformanceMeasureExpectedsUrl;
            UserHasEIPPerformanceMeasureExpectedManagePermissions = new EIPPerformanceMeasureExpectedFromProjectManageFeature().HasPermission(currentPerson, project).HasPermission;
            UserHasEIPPerformanceMeasureExpectedViewPermissions = new EIPPerformanceMeasureExpectedFromProjectViewFeature().HasPermission(currentPerson, project).HasPermission;

            EIPPerformanceMeasureReportedValuesGroupedViewData = eipPerformanceMeasureReportedValuesGroupedViewData;
            EditEIPPerformanceMeasureActualsUrl = editEIPPerformanceMeasureActualsUrl;
            UserHasEIPPerformanceMeasureActualManagePermissions = new EIPPerformanceMeasureActualFromProjectManageFeature().HasPermission(currentPerson, project).HasPermission;

            ProjectExpendituresSummaryViewData = projectExpendituresSummaryViewData;
            EditReportedExpendituresUrl = editReportedExpendituresUrl;
            UserHasProjectFundingSourceExpenditureManagePermissions = new ProjectFundingSourceExpenditureFromProjectManageFeature().HasPermission(currentPerson, project).HasPermission;

            EditThresholdCategoriesUrl = editThresholdCategoriesUrl;
            UserHasProjectThresholdCategoryManagePermissions = new ProjectEditFeature().HasPermissionByPerson(currentPerson);

            EditTransportationAssessmentUrl = editTransportationAssessmentUrl;

            EditLocalAndRegionalPlansUrl = editLocalAndRegionalPlansUrl;
            UserHasProjectLocalAndRegionalPlanManagePermissions = new ProjectLocalAndRegionalPlanManageFromProjectFeature().HasPermissionByPerson(currentPerson);

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

            EditTransportationProjectBudgetUrl = editTransportationProjectBudgetUrl;

            ProjectNotificationGridSpec = projectNotificationGridSpec;
            ProjectNotificationGridName = projectNotificationGridName;
            ProjectNotificationGridDataUrl = projectNotificationGridDataUrl;
        }
    }
}
