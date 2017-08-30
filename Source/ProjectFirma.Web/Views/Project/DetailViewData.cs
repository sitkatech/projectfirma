/*-----------------------------------------------------------------------
<copyright file="DetailViewData.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
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
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Views.Shared.PerformanceMeasureControls;
using ProjectFirma.Web.Views.Tag;

namespace ProjectFirma.Web.Views.Project
{
    public class DetailViewData : ProjectViewData
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
        public readonly ProjectBudgetDetailViewData ProjectBudgetDetailViewData;
        public readonly ProjectBasicsViewData ProjectBasicsViewData;
        public readonly ProjectLocationSummaryViewData ProjectLocationSummaryViewData;
        public readonly PerformanceMeasureExpectedSummaryViewData PerformanceMeasureExpectedSummaryViewData;
        public readonly PerformanceMeasureReportedValuesGroupedViewData PerformanceMeasureReportedValuesGroupedViewData;
        public readonly ProjectExpendituresDetailViewData ProjectExpendituresDetailViewData;
        public readonly ImageGalleryViewData ImageGalleryViewData;
        public readonly EntityNotesViewData EntityNotesViewData;
        public readonly EntityExternalLinksViewData EntityExternalLinksViewData;

        public readonly bool UserHasTaggingPermissions;
        public readonly ProjectBasicsTagsViewData ProjectBasicsTagsViewData;

        public readonly List<ProjectStage> ProjectStages;
        public readonly List<Models.ProjectOrganization> AllProjectOrganizations;
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

        public readonly string ClassificationDisplayName;
        public readonly string ClassificationDisplayNamePluralized;
        public readonly bool HasAssessment;
        public readonly string EditProjectWatershedFormID;
        public readonly string ProjectStewardCannotEditUrl;

        //TODO: Inline all url parameters

        public DetailViewData(Person currentPerson, Models.Project project, string confirmNonMandatoryUpdateUrl, List<ProjectStage> projectStages, ProjectTaxonomyViewData projectTaxonomyViewData,
            // TODO: Neutered per #1136; most likely will bring back when BOR project starts
            //ProjectBudgetDetailViewData projectBudgetDetailViewData, 
            ProjectLocationSummaryViewData projectLocationSummaryViewData, string mapFormID, string editSimpleProjectLocationUrl, string editDetailedProjectLocationUrl,
            string editProjectOrganizationsUrl, PerformanceMeasureExpectedSummaryViewData performanceMeasureExpectedSummaryViewData, string editPerformanceMeasureExpectedsUrl,
            PerformanceMeasureReportedValuesGroupedViewData performanceMeasureReportedValuesGroupedViewData, string editPerformanceMeasureActualsUrl,
            ProjectExpendituresDetailViewData projectExpendituresDetailViewData, string editReportedExpendituresUrl, 
            string editClassificationsUrl, string editAssessmentUrl, string editWatershedsUrl, ImageGalleryViewData imageGalleryViewData, 
            EntityNotesViewData entityNotesViewData, 
            AuditLogsGridSpec auditLogsGridSpec, string auditLogsGridDataUrl,
            // TODO: Neutered per #1136; most likely will bring back when BOR project starts
            //string editProjectBudgetUrl, 
            string editExternalLinksUrl, EntityExternalLinksViewData entityExternalLinksViewData, ProjectNotificationGridSpec projectNotificationGridSpec, string projectNotificationGridName, string projectNotificationGridDataUrl, ProjectBasicsViewData projectBasicsViewData, AssessmentTreeViewData assessmentTreeViewData) 
            : base(currentPerson, project)
        {
            PageTitle = project.DisplayName.ToEllipsifiedStringClean(110);
            BreadCrumbTitle = $"{Models.FieldDefinition.Project.GetFieldDefinitionLabel()} Detail";

            ConfirmNonMandatoryUpdateUrl = confirmNonMandatoryUpdateUrl;
            ProjectStages = projectStages;

            EditProjectUrl = project.GetEditUrl();
            UserHasProjectViewEverythingPermissions = new FirmaAdminFeature().HasPermissionByPerson(currentPerson);
            UserHasEditProjectPermissions = new ProjectEditFeature().HasPermission(currentPerson, project).HasPermission;
            UserHasProjectUpdatePermissions = new ProjectUpdateCreateEditSubmitFeature().HasPermission(CurrentPerson, project).HasPermission;
            ProjectBasicsViewData = projectBasicsViewData;
            AssessmentTreeViewData = assessmentTreeViewData;

            UserHasTaggingPermissions = new TagManageFeature().HasPermissionByPerson(CurrentPerson);
            var tagHelper = new TagHelper(project.ProjectTags.Select(x => new BootstrapTag(x.Tag)).ToList());
            ProjectBasicsTagsViewData = new ProjectBasicsTagsViewData(project, tagHelper);

            ProjectTaxonomyViewData = projectTaxonomyViewData;

            // TODO: Neutered per #1136; most likely will bring back when BOR project starts
            //ProjectBudgetDetailViewData = projectBudgetDetailViewData;
            //UserHasProjectBudgetManagePermissions = new ProjectBudgetManageFeature().HasPermissionByPerson(currentPerson);
            //EditProjectBudgetUrl = editProjectBudgetUrl;

            ProjectLocationSummaryViewData = projectLocationSummaryViewData;
            MapFormID = mapFormID;
            EditSimpleProjectLocationUrl = editSimpleProjectLocationUrl;
            EditDetailedProjectLocationUrl = editDetailedProjectLocationUrl;
            UserHasMapManagePermissions = new ProjectMapManageFeature().HasPermission(currentPerson, project).HasPermission;

            AllProjectOrganizations = project.ProjectOrganizations.ToList();
            EditProjectOrganizationsUrl = editProjectOrganizationsUrl;
            UserHasProjectOrganizationManagePermissions = new ProjectOrganizationManageFeature().HasPermission(currentPerson, project).HasPermission;

            PerformanceMeasureExpectedSummaryViewData = performanceMeasureExpectedSummaryViewData;
            EditPerformanceMeasureExpectedsUrl = editPerformanceMeasureExpectedsUrl;
            UserHasPerformanceMeasureExpectedManagePermissions = new PerformanceMeasureExpectedFromProjectManageFeature().HasPermission(currentPerson, project).HasPermission;
            UserHasPerformanceMeasureExpectedViewPermissions = new PerformanceMeasureExpectedFromProjectViewFeature().HasPermission(currentPerson, project).HasPermission;

            PerformanceMeasureReportedValuesGroupedViewData = performanceMeasureReportedValuesGroupedViewData;
            EditPerformanceMeasureActualsUrl = editPerformanceMeasureActualsUrl;
            UserHasPerformanceMeasureActualManagePermissions = new PerformanceMeasureActualFromProjectManageFeature().HasPermission(currentPerson, project).HasPermission;

            ProjectExpendituresDetailViewData = projectExpendituresDetailViewData;
            EditReportedExpendituresUrl = editReportedExpendituresUrl;
            UserHasProjectFundingSourceExpenditureManagePermissions = new ProjectFundingSourceExpenditureFromProjectManageFeature().HasPermission(currentPerson, project).HasPermission;

            EditClassificationsUrl = editClassificationsUrl;
            UserHasProjectClassificationManagePermissions = new ProjectEditFeature().HasPermission(currentPerson, project).HasPermission;

            EditAssessmentUrl = editAssessmentUrl;

            EditWatershedsUrl = editWatershedsUrl;
            UserHasProjectWatershedManagePermissions = new ProjectWatershedManageFromProjectFeature().HasPermission(currentPerson, project).HasPermission;

            EditExternalLinksUrl = editExternalLinksUrl;
            EntityExternalLinksViewData = entityExternalLinksViewData;
            UserHasProjectExternalLinkManagePermissions = new ProjectExternalLinkManageFeature().HasPermission(currentPerson, project).HasPermission;

            ImageGalleryViewData = imageGalleryViewData;

            EntityNotesViewData = entityNotesViewData;

            ProjectUpdateBatchGridSpec = new ProjectUpdateBatchGridSpec() { ObjectNameSingular = $"{Models.FieldDefinition.Project.GetFieldDefinitionLabel()} Update", ObjectNamePlural = $"{Models.FieldDefinition.Project.GetFieldDefinitionLabel()} Updates", SaveFiltersInCookie = true };
            ProjectUpdateBatchGridName = "projectUpdateBatch";
            ProjectUpdateBatchGridDataUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(x => x.ProjectUpdateBatchGridJsonData(project.ProjectID));

            AuditLogsGridSpec = auditLogsGridSpec;
            AuditLogsGridName = "projectAuditLogsGrid";
            AuditLogsGridDataUrl = auditLogsGridDataUrl;


            ProjectNotificationGridSpec = projectNotificationGridSpec;
            ProjectNotificationGridName = projectNotificationGridName;
            ProjectNotificationGridDataUrl = projectNotificationGridDataUrl;

            HasAssessment = false;

            ClassificationDisplayNamePluralized = Models.FieldDefinition.Classification.GetFieldDefinitionLabelPluralized();
            ClassificationDisplayName = Models.FieldDefinition.Classification.GetFieldDefinitionLabel();

            EditProjectWatershedFormID = ProjectWatershedController.GetEditProjectWatershedsFormID();

            ProjectStewardCannotEditUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(c => c.ProjectStewardCannotEdit());
        }
    }
}
