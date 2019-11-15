using System;
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using static LtInfo.Common.DateUtilities;

namespace ProjectFirma.Web.Models
{
    public class ProjectTimeline
    {
        public Project Project { get; }

        private List<IProjectTimelineEvent> TimelineEvents { get; }

        public ProjectTimeline(Project project)
        {
            Project = project;
            TimelineEvents = new List<IProjectTimelineEvent>();
            TimelineEvents.Add(GetTimelineCreateEvent(project));
            TimelineEvents.Add(GetTimelineApprovalEvent(project));
            TimelineEvents.AddRange(GetTimelineUpdateEvents(project));
            GetGroupedTimelineEvents();
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
            return approvedProjectUpdateBatches.Any() ? approvedProjectUpdateBatches.Select(apub => new ProjectTimelineUpdateEvent(apub)).ToList() : null;
        }

        // this hopefully return some sort of grouped list for display
        public List<IGrouping<int, IGrouping<QuarterGroup, IGrouping<DayGroup, IProjectTimelineEvent>>>> GetGroupedTimelineEvents()
        {
            var timelineEventsGrouped = TimelineEvents
                .GroupBy(x => new DayGroup{ Day = x.Date.Day, Month = x.Date.Month, Quarter = x.Quarter, Year = x.Date.Year })
                .GroupBy(y => new QuarterGroup{ Quarter = y.Key.Quarter, Year = y.Key.Year })
                .GroupBy(z => z.Key.Year).ToList();
            return timelineEventsGrouped;
        }

        public struct DayGroup
        {
            public int Day;
            public FiscalQuarter Quarter;
            public int Month;
            public int Year;
        }

        public struct QuarterGroup
        {
            public FiscalQuarter Quarter;
            public int Year;
        }

    }


    public class ProjectTimelineCreateEvent : IProjectTimelineEvent
    {
        public DateTime Date { get; }
        public FiscalQuarter Quarter { get; }
     
        public ProjectTimelineEventType ProjectTimelineEventType { get; }
        public string TimelineEventTypeDisplayName { get; }
        public string TimelineEventPersonDisplayName { get; }
        public string TimelineDetailsLink { get; }
        public string TimelineSide { get; }
        public string Color { get; }

        public ProjectTimelineCreateEvent(Project project)
        {
            if (project.SubmissionDate == null)
            {
                throw new SitkaProjectTimelineException("Cannot create a timeline create event with a project that does not have a submission date.");
            }
            Date = (DateTime)project.SubmissionDate;
            Quarter = FirmaDateUtilities.CalculateFiscalQuarter((DateTime)Date);
            ProjectTimelineEventType = ProjectTimelineEventType.Create;
            TimelineEventTypeDisplayName = "Created";
            TimelineEventPersonDisplayName = project.ProposingPerson.GetFullNameFirstLast();

        }

    }

    public class ProjectTimelineApprovalEvent : IProjectTimelineEvent
    {
        public DateTime Date { get; }
        public FiscalQuarter Quarter { get; }
        public int Year { get; }
        public ProjectTimelineEventType ProjectTimelineEventType { get; }
        public string TimelineEventTypeDisplayName { get; }
        public string TimelineEventPersonDisplayName { get; }
        public string TimelineDetailsLink { get; }
        public string TimelineSide { get; }
        public string Color { get; }

        public ProjectTimelineApprovalEvent(Project project)
        {
            if (project.ApprovalDate == null)
            {
                throw new SitkaProjectTimelineException("Cannot create a timeline approval event with a project that does not have an approval date.");
            }
            Date = (DateTime)project.ApprovalDate;
            Quarter = FirmaDateUtilities.CalculateFiscalQuarter((DateTime)Date);
            ProjectTimelineEventType = ProjectTimelineEventType.Approve;
            TimelineEventTypeDisplayName = "Approved";
            TimelineEventPersonDisplayName = project.ReviewedByPerson.GetFullNameFirstLast();
        }

    }

    public class ProjectTimelineUpdateEvent : IProjectTimelineEvent
    {
        public DateTime Date { get; }
        public FiscalQuarter Quarter { get; }
        public ProjectTimelineEventType ProjectTimelineEventType { get; }
        public string TimelineEventTypeDisplayName { get; }
        public string TimelineEventPersonDisplayName { get; }
        public string TimelineDetailsLink { get; }
        public string TimelineSide { get; }
        public string Color { get; }

        public ProjectTimelineUpdateEvent(ProjectUpdateBatch projectUpdateBatch)
        {
            var approvedProjectUpdateHistory = projectUpdateBatch.ProjectUpdateHistories.First(x => x.ProjectUpdateState == ProjectUpdateState.Approved);

            Date = approvedProjectUpdateHistory.TransitionDate;
            Quarter = FirmaDateUtilities.CalculateFiscalQuarter(Date);
            ProjectTimelineEventType = ProjectTimelineEventType.Update;
            TimelineEventTypeDisplayName = "Update";
            TimelineEventPersonDisplayName = approvedProjectUpdateHistory.UpdatePerson.GetFullNameFirstLast();
        }
    }



    public interface IProjectTimelineEvent
    {
        DateTime Date { get; }
        DateUtilities.FiscalQuarter Quarter { get; }
        ProjectTimelineEventType ProjectTimelineEventType { get; }
        string TimelineEventTypeDisplayName { get; }
        string TimelineEventPersonDisplayName { get; }
        string TimelineDetailsLink { get; }
        string TimelineSide { get; }
        string Color { get; }
    }

    public enum ProjectTimelineEventType
    {
        Create,
        Approve,
        Update
    }

    public class SitkaProjectTimelineException : Exception
    {
        public SitkaProjectTimelineException(string message) : base(message)
        {
        }
    }

}