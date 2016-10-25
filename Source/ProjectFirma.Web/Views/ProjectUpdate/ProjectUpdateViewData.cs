using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public enum ProjectUpdateSectionEnum
    {
        Instructions,
        Basics,
        EIPPerformanceMeasures,
        Expenditures,
        Photos,
        LocationSimple,
        LocationDetailed,
        Notes,
        History,
        TransportationBudgets,
        ExternalLinks
    }

    public class ProjectUpdateViewData : FirmaViewData
    {
        public readonly ProjectUpdateSectionEnum SelectedProjectUpdateSection;
        public readonly ProjectUpdateBatch ProjectUpdateBatch;
        public readonly Models.Project Project;
        public readonly string ProjectUpdateMyProjectsUrl;
        public readonly string ProjectUpdateInstructionsUrl;
        public readonly string ProjectUpdateBasicsUrl;
        public readonly string ProjectUpdateEIPPerformanceMeasuresUrl;
        public readonly string ProjectUpdateExpendituresUrl;
        public readonly string ProjectUpdateTransportationBudgetsUrl;
        public readonly string ProjectUpdatePhotosUrl;
        public readonly string ProjectUpdateLocationSimpleUrl;
        public readonly string ProjectUpdateLocationDetailedUrl;
        public readonly string ProjectUpdateNotesUrl;
        public readonly string ProjectUpdateExternalLinksUrl;
        public readonly string ProjectUpdateHistoryUrl;
        public readonly string DeleteProjectUpdateUrl;
        public readonly string SubmitUrl;
        public readonly string ApproveUrl;
        public readonly string ReturnUrl;

        public readonly bool IsEditable;
        public readonly bool IsReadyToApprove;
        public readonly bool ShowApproveAndReturnButton;
        public readonly bool AreProjectBasicsValid;
        public readonly UpdateStatus UpdateStatus;

        public ProjectUpdateViewData(Person currentPerson, ProjectUpdateBatch projectUpdateBatch, ProjectUpdateSectionEnum selectedProjectUpdateSection, UpdateStatus updateStatus) : base(currentPerson)
        {
            SelectedProjectUpdateSection = selectedProjectUpdateSection;
            ProjectUpdateBatch = projectUpdateBatch;
            Project = ProjectUpdateBatch.Project;
            HtmlPageTitle += " - Project Updates";
            EntityName = string.Format("Project Update for Reporting Year: {0}", ProjectFirmaDateUtilities.CalculateCurrentYearToUseForReporting());
            PageTitle = Project.DisplayName;
            ProjectUpdateMyProjectsUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.MyProjectsRequiringAnUpdate());
            ProjectUpdateInstructionsUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Instructions(Project));
            ProjectUpdateBasicsUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Basics(Project));
            ProjectUpdateEIPPerformanceMeasuresUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.EIPPerformanceMeasures(Project));
            ProjectUpdateExpendituresUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Expenditures(Project));
            ProjectUpdateTransportationBudgetsUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.TransportationBudgets(Project));
            ProjectUpdatePhotosUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Photos(Project));
            ProjectUpdateLocationSimpleUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.LocationSimple(Project));
            ProjectUpdateLocationDetailedUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.LocationDetailed(Project));
            ProjectUpdateExternalLinksUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.ExternalLinks(Project));
            ProjectUpdateNotesUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Notes(Project));
            ProjectUpdateHistoryUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.History(Project));
            DeleteProjectUpdateUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.DeleteProjectUpdate(Project));
            SubmitUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Submit(Project));
            ApproveUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Approve(Project));
            ReturnUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Return(Project));
            var isApprover = new ProjectUpdateAdminFeature().HasPermissionByPerson(CurrentPerson);
            ShowApproveAndReturnButton = projectUpdateBatch.IsSubmitted && isApprover;
            IsEditable = projectUpdateBatch.InEditableState || ShowApproveAndReturnButton;
            IsReadyToApprove = projectUpdateBatch.IsReadyToApprove;
            AreProjectBasicsValid = projectUpdateBatch.AreProjectBasicsValid;

            //Neuter UpdateStatus for non-approver users until we go live with "Show Changes" for all users.
            UpdateStatus = CurrentPerson.IsApprover() ? updateStatus : new UpdateStatus(false, false, false, false, false, false, false, false, false);

        }
    }
}