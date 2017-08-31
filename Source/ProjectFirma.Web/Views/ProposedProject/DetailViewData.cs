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
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared.ProjectControls;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.TextControls;
using LtInfo.Common;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared.PerformanceMeasureControls;

namespace ProjectFirma.Web.Views.ProposedProject
{
    public class DetailViewData : ProposedProjectViewData
    {
        public readonly string EditProposedProjectUrl;
        public readonly string EditMapUrl;
        public readonly string ApproveProjectUrl;
        public readonly ProjectLocationSummaryViewData ProjectLocationSummaryViewData;
        public readonly string ProposedProjectsUrl;
        public readonly bool UserHasProposedProjectClassificationManagePermissions;
        public readonly string EditClassificationsUrl;

        public readonly string MapFormID;
        public readonly string EditPerformanceMeasureExpectedsUrl;
        public readonly PerformanceMeasureExpectedSummaryViewData PerformanceMeasureExpectedSummaryViewData;

        public readonly AuditLogsGridSpec AuditLogsGridSpec;
        public readonly string AuditLogsGridName;
        public readonly string AuditLogsGridDataUrl;
        public readonly EntityNotesViewData EntityNotesViewData;

        public readonly ImageGalleryViewData ImageGalleryViewData;

        public AssessmentTreeViewData AssessmentTreeViewData;

        public readonly Models.Tenant Tenant;


        public DetailViewData(Person currentPerson,
            Models.ProposedProject proposedProject,
            ProjectLocationSummaryViewData projectLocationSummaryViewData,
            PerformanceMeasureExpectedSummaryViewData performanceMeasureExpectedSummaryViewData,
            ImageGalleryViewData imageGalleryViewData,
            EntityNotesViewData entityNotesViewData,
            string mapFormID,
            AssessmentTreeViewData assessmentTreeViewData,
            Models.Tenant tenant) : base(currentPerson, proposedProject, ProposedProjectSectionEnum.Basics, new ProposalSectionsStatus(proposedProject))
        {
            PageTitle = proposedProject.DisplayName;
            BreadCrumbTitle = $"{Models.FieldDefinition.ProposedProject.GetFieldDefinitionLabel()} Detail";
            MapFormID = mapFormID;

            UserHasProposedProjectClassificationManagePermissions = new ProjectEditFeature().HasPermissionByPerson(currentPerson);

            EditProposedProjectUrl = proposedProject.GetEditUrl();
            EditMapUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.EditLocationSimple(proposedProject));
            ApproveProjectUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.Approve(proposedProject));
            EditPerformanceMeasureExpectedsUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.EditExpectedPerformanceMeasureValues(proposedProject));
            ProposedProjectsUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.Index());
            EditClassificationsUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(c => c.EditClassifications(proposedProject));

            ProjectLocationSummaryViewData = projectLocationSummaryViewData;
            PerformanceMeasureExpectedSummaryViewData = performanceMeasureExpectedSummaryViewData;
            ImageGalleryViewData = imageGalleryViewData;
            EntityNotesViewData = entityNotesViewData;

            AuditLogsGridSpec = new AuditLogsGridSpec() {ObjectNameSingular = "Change", ObjectNamePlural = "Changes", SaveFiltersInCookie = true};
            AuditLogsGridName = "proposedProjectAuditLogsGrid";
            AuditLogsGridDataUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(tc => tc.AuditLogsGridJsonData(proposedProject));

            AssessmentTreeViewData = assessmentTreeViewData;

            Tenant = tenant;
        }
    }
}
