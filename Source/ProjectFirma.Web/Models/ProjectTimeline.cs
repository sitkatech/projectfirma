using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.BootstrapWrappers;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.ModalDialog;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;
using static LtInfo.Common.DateUtilities;

namespace ProjectFirma.Web.Models
{
    public class ProjectTimeline
    {
        public Project Project { get; }

        private List<IProjectTimelineEvent> TimelineEvents { get; }
        public const string DisplayClass = "open";
        public bool UsesFiscalYears { get; }

        public ProjectTimeline(Project project, bool canEditProjectProjectStatus, bool canEditFinalStatusReport)
        {
            Project = project;
            TimelineEvents = new List<IProjectTimelineEvent>();
            AddProjectCreateEventToTimelineIfExists();
            AddProjectApprovalEventToTimelineIfExists();
            TimelineEvents.AddRange(GetTimelineUpdateEvents(Project));
            TimelineEvents.AddRange(GetTimelineProjectStatusChangeEvents(Project, canEditProjectProjectStatus, canEditFinalStatusReport));
            UsesFiscalYears = MultiTenantHelpers.UseFiscalYears();
        }

        private void AddProjectApprovalEventToTimelineIfExists()
        {
            var projectTimelineApprovalEvent = GetTimelineApprovalEvent(Project);
            if (projectTimelineApprovalEvent != null)
            {
                TimelineEvents.Add(projectTimelineApprovalEvent);
            }
        }

        private void AddProjectCreateEventToTimelineIfExists()
        {
            var projectTimelineCreateEvent = GetTimelineCreateEvent(Project);
            if (projectTimelineCreateEvent != null)
            {
                TimelineEvents.Add(projectTimelineCreateEvent);
            }
        }

        private ProjectTimelineCreateEvent GetTimelineCreateEvent(Project project)
        {
            return project.SubmissionDate != null ? new ProjectTimelineCreateEvent(project) : null;
        }

        private ProjectTimelineApprovalEvent GetTimelineApprovalEvent(Project project)
        {
            return project.ApprovalDate != null ? new ProjectTimelineApprovalEvent(project) : null;
        }

        private List<ProjectTimelineUpdateEvent> GetTimelineUpdateEvents(Project project)
        {
            var approvedProjectUpdateBatches = project.ProjectUpdateBatches.Where(pub =>
                pub.ProjectUpdateHistories.Any(pus => pus.ProjectUpdateState == ProjectUpdateState.Approved)).ToList();
            return approvedProjectUpdateBatches.Any() ? approvedProjectUpdateBatches.Select(apub => new ProjectTimelineUpdateEvent(apub)).ToList() : new List<ProjectTimelineUpdateEvent>();
        }

        private List<ProjectTimelineProjectStatusChangeEvent> GetTimelineProjectStatusChangeEvents(Project project, bool canEditProjecProjectStatus, bool canEditFinalStatusReport)
        {
            var projectStatusChangeEvents = project.ProjectProjectStatuses
                .Select(x => new ProjectTimelineProjectStatusChangeEvent(x, canEditProjecProjectStatus, canEditFinalStatusReport))
                .OrderByDescending(y => y.ProjectProjectStatus.ProjectProjectStatusID)
                .ToList();
            return projectStatusChangeEvents;
        }

        // this hopefully return some sort of grouped list for display
        public List<IGrouping<YearGroup, IGrouping<QuarterGroup, IGrouping<DayGroup, IProjectTimelineEvent>>>> GetGroupedTimelineEvents()
        {
            var startDate = MultiTenantHelpers.GetStartDayOfReportingYear();
            var startMonth = startDate.Month;
            var timelineEventsGrouped = TimelineEvents
                .OrderByDescending(a => a.Date)
                .GroupBy(x => new DayGroup
                {
                    Day = x.Date.Day, 
                    Month = x.Date.Month, 
                    Quarter = x.Quarter, 
                    Year = UsesFiscalYears ? x.Date.GetFiscalYearFromStartMonth((DateUtilities.Month)startMonth) : x.Date.Year
                }).ToList()
                .GroupBy(y => new QuarterGroup{ Quarter = y.Key.Quarter, Year = y.Key.Year }).ToList()
                .GroupBy(z => new YearGroup {Year = z.Key.Year })
                .ToList();

            return timelineEventsGrouped;
        }

        public struct DayGroup
        {
            public int Day;
            public Quarter Quarter;
            public int Month;
            public int Year;
        }

        public struct QuarterGroup
        {
            public Quarter Quarter;
            public int Year;
        }

        public struct YearGroup
        {
            public int Year;
        }

        

        public static HtmlString MakeProjectStatusEditLinkButton(ProjectProjectStatus projectProjectStatus, bool canEditProjectStatus, bool canEditFinalStatusReport)
        {
            var editIconAsModalDialogLinkBootstrap = new HtmlString(string.Empty);
            if ((canEditProjectStatus && !projectProjectStatus.IsFinalStatusUpdate) || (canEditFinalStatusReport && projectProjectStatus.IsFinalStatusUpdate))
            {
                editIconAsModalDialogLinkBootstrap = DhtmlxGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(
                    projectProjectStatus.GetEditProjectProjectStatusUrl()
                    , $"Add {FieldDefinitionEnum.StatusUpdate.ToType().GetFieldDefinitionLabel()} Details:");
            }
            return editIconAsModalDialogLinkBootstrap;
        }
        public static HtmlString MakeProjectStatusDeleteLinkButton(ProjectProjectStatus projectProjectStatus, bool canEditProjectStatus, bool canEditFinalStatusReport)
        {
            var deleteIconAsModalDialogLinkBootstrap = new HtmlString(string.Empty);
            if ((canEditProjectStatus && !projectProjectStatus.IsFinalStatusUpdate) || (canEditFinalStatusReport && projectProjectStatus.IsFinalStatusUpdate))
            {
                deleteIconAsModalDialogLinkBootstrap = ModalDialogFormHelper.MakeDeleteLink(
                    BootstrapHtmlHelpers.MakeGlyphIconWithScreenReaderOnlyText("glyphicon-trash",
                        "Delete status report").ToString(),
                    projectProjectStatus.GetDeleteProjectProjectStatusUrl(), new List<string> { }, true);
            }
            return deleteIconAsModalDialogLinkBootstrap;
        }

        public static HtmlString MakeProjectStatusDetailsLinkButton(ProjectProjectStatus projectProjectStatus)
        {
            var detailsLink = ModalDialogFormHelper.ModalDialogFormLinkHiddenSave(
                null,
                "Show Details",
                projectProjectStatus.GetProjectProjectStatusDetailsUrl()
                , $"{FieldDefinitionEnum.StatusUpdate.ToType().GetFieldDefinitionLabel()} Details"
                , 900
                ,"Close"
                , new List<string>());
            return detailsLink;
        }

        public static HtmlString MakeProjectUpdateDetailsLinkButton(ProjectUpdateBatch projectUpdateBatch)
        {
            var url = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(c => c.ProjectUpdateBatchDiff(projectUpdateBatch));
            var detailsLink = ModalDialogFormHelper.ModalDialogFormLinkHiddenSave(
                "diff-link-id",
                "Show Details",
                url
                , $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Update Change Log"
                , 1000
                , "Close"
                , new List<string>());
            return detailsLink;
        }


    }


    public class ProjectTimelineCreateEvent : IProjectTimelineEvent
    {
        public DateTime Date { get; }
        public string DateDisplay { get; }
        public int? FiscalYear { get; }
        public Quarter Quarter { get; }
     
        public ProjectTimelineEventType ProjectTimelineEventType { get; }
        public string TimelineEventTypeDisplayName { get; }
        public HtmlString TimelineEventPersonDisplayName { get; }
        public string TimelineDetailsLink { get; }
        public ProjectTimelineSide ProjectTimelineSide { get; }
        public string Color { get; }
        public HtmlString EditButton { get; }
        public HtmlString DeleteButton { get; }
        public HtmlString ShowDetailsLinkHtmlString { get; }


        public ProjectTimelineCreateEvent(Project project)
        {
            if (project.SubmissionDate == null)
            {
                throw new SitkaProjectTimelineException("Cannot create a timeline create event with a project that does not have a submission date.");
            }
            Date = (DateTime)project.SubmissionDate;
            DateDisplay = Date.ToString("MMM dd, yyyy");
            FiscalYear = FirmaDateUtilities.CalculateFiscalYearForTenant(Date);
            Quarter = (Quarter)FirmaDateUtilities.CalculateQuarterForTenant(Date);
            ProjectTimelineEventType = ProjectTimelineEventType.Create;
            TimelineEventTypeDisplayName = "Created";
            TimelineEventPersonDisplayName = project.ProposingPerson.GetPersonDisplayNameWithContactTypesListForProject(project);
            ProjectTimelineSide = ProjectTimelineSide.Left;
            EditButton = new HtmlString(string.Empty);
            DeleteButton = new HtmlString(string.Empty);
            ShowDetailsLinkHtmlString = new HtmlString(string.Empty);

        }
    }


    public class ProjectTimelineProjectStatusChangeEvent : IProjectTimelineEvent
    {
        public DateTime Date { get; }
        public string DateDisplay { get; }
        public int? FiscalYear { get; }
        public Quarter Quarter { get; }
        public ProjectTimelineEventType ProjectTimelineEventType { get; }
        public string TimelineEventTypeDisplayName { get; }
        public HtmlString TimelineEventPersonDisplayName { get; }
        public string TimelineDetailsLink { get; }
        public ProjectTimelineSide ProjectTimelineSide { get; }
        public string Color { get; }
        public HtmlString EditButton { get; }
        public HtmlString DeleteButton { get; }
        public HtmlString ShowDetailsLinkHtmlString { get; }
        public ProjectProjectStatus ProjectProjectStatus { get; }

        public ProjectTimelineProjectStatusChangeEvent(ProjectProjectStatus projectProjectStatus, bool canEditProjectProjectStatus, bool canEditFinalStatusReport)
        {
            Date = projectProjectStatus.ProjectProjectStatusUpdateDate;
            DateDisplay = Date.ToString("MMM dd, yyyy");
            FiscalYear = FirmaDateUtilities.CalculateFiscalYearForTenant(Date);
            Quarter = (Quarter)FirmaDateUtilities.CalculateQuarterForTenant(Date);
            ProjectTimelineEventType = ProjectTimelineEventType.ProjectStatusChange;
            TimelineEventTypeDisplayName = projectProjectStatus.IsFinalStatusUpdate ? "Final Status Update" : "Status Updated";
            TimelineEventPersonDisplayName = projectProjectStatus.ProjectProjectStatusCreatePerson.GetPersonDisplayNameWithContactTypesListForProject(projectProjectStatus.Project);
            ProjectTimelineSide = ProjectTimelineSide.Right;

            EditButton = ProjectTimeline.MakeProjectStatusEditLinkButton(projectProjectStatus, canEditProjectProjectStatus, canEditFinalStatusReport);
            DeleteButton = ProjectTimeline.MakeProjectStatusDeleteLinkButton(projectProjectStatus, canEditProjectProjectStatus, canEditFinalStatusReport);
            Color = projectProjectStatus.ProjectStatus.ProjectStatusColor;
            ShowDetailsLinkHtmlString = ProjectTimeline.MakeProjectStatusDetailsLinkButton(projectProjectStatus);
            ProjectProjectStatus = projectProjectStatus;
        }
    }

    public class ProjectTimelineApprovalEvent : IProjectTimelineEvent
    {
        public DateTime Date { get; }
        public string DateDisplay { get; }
        public Quarter Quarter { get; }
        public int? FiscalYear { get; }
        public ProjectTimelineEventType ProjectTimelineEventType { get; }
        public string TimelineEventTypeDisplayName { get; }
        public HtmlString TimelineEventPersonDisplayName { get; }
        public string TimelineDetailsLink { get; }
        public ProjectTimelineSide ProjectTimelineSide { get; }
        public string Color { get; }
        public HtmlString EditButton { get; }
        public HtmlString DeleteButton { get; }
        public HtmlString ShowDetailsLinkHtmlString { get; }

        public ProjectTimelineApprovalEvent(Project project)
        {
            if (project.ApprovalDate == null)
            {
                throw new SitkaProjectTimelineException("Cannot create a timeline approval event with a project that does not have an approval date.");
            }
            Date = (DateTime)project.ApprovalDate;
            DateDisplay = Date.ToString("MMM dd, yyyy");
            FiscalYear = FirmaDateUtilities.CalculateFiscalYearForTenant(Date);
            Quarter = (Quarter)FirmaDateUtilities.CalculateQuarterForTenant(Date);
            ProjectTimelineEventType = ProjectTimelineEventType.Approve;
            TimelineEventTypeDisplayName = "Approved";
            TimelineEventPersonDisplayName = project.ReviewedByPerson?.GetPersonDisplayNameWithContactTypesListForProject(project);
            ProjectTimelineSide = ProjectTimelineSide.Left;
            EditButton = new HtmlString(string.Empty);
            DeleteButton = new HtmlString(string.Empty);
            ShowDetailsLinkHtmlString = new HtmlString(string.Empty);
        }

    }

    public class ProjectTimelineUpdateEvent : IProjectTimelineEvent
    {
        public DateTime Date { get; }
        public string DateDisplay { get; }
        public int? FiscalYear { get; }
        public Quarter Quarter { get; }
        public ProjectTimelineEventType ProjectTimelineEventType { get; }
        public string TimelineEventTypeDisplayName { get; }
        public HtmlString TimelineEventPersonDisplayName { get; }
        public string TimelineDetailsLink { get; }
        public ProjectTimelineSide ProjectTimelineSide { get; }
        public string Color { get; }
        public HtmlString EditButton { get; }
        public HtmlString DeleteButton { get; }
        public HtmlString ShowDetailsLinkHtmlString { get; }

        public ProjectTimelineUpdateEvent(ProjectUpdateBatch projectUpdateBatch)
        {
            var approvedProjectUpdateHistory = projectUpdateBatch.ProjectUpdateHistories.First(x => x.ProjectUpdateState == ProjectUpdateState.Approved);

            Date = approvedProjectUpdateHistory.TransitionDate;
            DateDisplay = Date.ToString("MMM dd, yyyy");
            FiscalYear = FirmaDateUtilities.CalculateFiscalYearForTenant(Date);
            Quarter = (Quarter) FirmaDateUtilities.CalculateQuarterForTenant(Date);
            ProjectTimelineEventType = ProjectTimelineEventType.Update;
            TimelineEventTypeDisplayName = "Update";
            TimelineEventPersonDisplayName = approvedProjectUpdateHistory.UpdatePerson.GetPersonDisplayNameWithContactTypesListForProject(projectUpdateBatch.Project);
            ProjectTimelineSide = ProjectTimelineSide.Left;
            EditButton = new HtmlString(string.Empty);
            DeleteButton = new HtmlString(string.Empty);
            ShowDetailsLinkHtmlString = ProjectTimeline.MakeProjectUpdateDetailsLinkButton(projectUpdateBatch);
        }
    }



    public interface IProjectTimelineEvent
    {
        DateTime Date { get; }
        string DateDisplay { get; }
        int? FiscalYear { get; }
        Quarter Quarter { get; }
        ProjectTimelineEventType ProjectTimelineEventType { get; }
        string TimelineEventTypeDisplayName { get; }
        HtmlString TimelineEventPersonDisplayName { get; }
        string TimelineDetailsLink { get; }
        ProjectTimelineSide ProjectTimelineSide { get; }
        string Color { get; }
        HtmlString EditButton { get; }
        HtmlString DeleteButton { get; }
        HtmlString ShowDetailsLinkHtmlString { get; }
    }

    public enum ProjectTimelineEventType
    {
        Create,
        Approve,
        Update,
        ProjectStatusChange
    }

    public enum ProjectTimelineSide
    {
        Left,
        Right
    }

    public class SitkaProjectTimelineException : Exception
    {
        public SitkaProjectTimelineException(string message) : base(message)
        {
        }
    }


}