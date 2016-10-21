using ProjectFirma.Web.Areas.EIP.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Areas.EIP.Views.Shared.EIPPerformanceMeasureControls;
using ProjectFirma.Web.Areas.EIP.Views.Shared.ProjectControls;
using ProjectFirma.Web.Areas.EIP.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.TextControls;
using LtInfo.Common;

namespace ProjectFirma.Web.Areas.EIP.Views.ProposedProject
{
    public class SummaryViewData : ProposedProjectViewData
    {
        public readonly string EditProposedProjectUrl;
        public readonly string EditMapUrl;
        public readonly string ApproveProjectUrl;
        public readonly ProjectLocationSummaryViewData ProjectLocationSummaryViewData;
        public readonly string ProposedProjectsUrl;
        public readonly string EditThresholdCategoriesUrl;

        public readonly string FiveYearListUrl;

        public readonly string MapFormID;
        public readonly string EditEIPPerformanceMeasureExpectedsUrl;
        public readonly EIPPerformanceMeasureExpectedSummaryViewData EIPPerformanceMeasureExpectedSummaryViewData;

        public readonly AuditLogsGridSpec AuditLogsGridSpec;
        public readonly string AuditLogsGridName;
        public readonly string AuditLogsGridDataUrl;
        public readonly EntityNotesViewData EntityNotesViewData;

        public readonly ImageGalleryViewData ImageGalleryViewData;

        public TransportationAssessmentTreeViewData TransportationAssessmentTreeViewData;

        public SummaryViewData(Person currentPerson, Models.ProposedProject proposedProject, ProjectLocationSummaryViewData projectLocationSummaryViewData, EIPPerformanceMeasureExpectedSummaryViewData eipPerformanceMeasureExpectedSummaryViewData, ImageGalleryViewData imageGalleryViewData, EntityNotesViewData entityNotesViewData, string mapFormID, TransportationAssessmentTreeViewData transportationAssessmentTreeViewData) : base(currentPerson, proposedProject, ProposedProjectSectionEnum.Basics, new ProposalSectionsStatus(proposedProject))
        {
            PageTitle = proposedProject.DisplayName;
            BreadCrumbTitle = "Proposed Project Summary";
            MapFormID = mapFormID;

            FiveYearListUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(x => x.FiveYearList());
            EditProposedProjectUrl = proposedProject.GetEditUrl();
            EditMapUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.EditLocationSimple(proposedProject));
            ApproveProjectUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.Approve(proposedProject));
            EditEIPPerformanceMeasureExpectedsUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.EditExpectedEIPPerformanceMeasureValues(proposedProject));
            ProposedProjectsUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.Index());
            EditThresholdCategoriesUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(c => c.EditThresholdCategories(proposedProject));

            ProjectLocationSummaryViewData = projectLocationSummaryViewData;
            EIPPerformanceMeasureExpectedSummaryViewData = eipPerformanceMeasureExpectedSummaryViewData;
            ImageGalleryViewData = imageGalleryViewData;
            EntityNotesViewData = entityNotesViewData;

            AuditLogsGridSpec = new AuditLogsGridSpec() {ObjectNameSingular = "Change", ObjectNamePlural = "Changes", SaveFiltersInCookie = true};
            AuditLogsGridName = "proposedProjectAuditLogsGrid";
            AuditLogsGridDataUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(tc => tc.AuditLogsGridJsonData(proposedProject));

            TransportationAssessmentTreeViewData = transportationAssessmentTreeViewData;
        }

        
    }
}
