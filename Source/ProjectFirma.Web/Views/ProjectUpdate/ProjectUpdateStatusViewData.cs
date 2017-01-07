using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class ProjectUpdateStatusViewData : FirmaViewData
    {
        public readonly int ReportingYear;

        public readonly PeopleReceivingReminderGridSpec PeopleReceivingReminderGridSpec;
        public readonly string PeopleReceivingReminderGridName;
        public readonly string PeopleReceivingReminderGridDataUrl;

        public ProjectUpdateStatusViewData(Person currentPerson,
            Models.FirmaPage firmaPage,                        
            PeopleReceivingReminderGridSpec peopleReceivingReminderGridSpec,
            string peopleReceivingReminderGridDataUrl) : base(currentPerson, firmaPage, false)
        {
            var reportingYear = FirmaDateUtilities.CalculateCurrentYearToUseForReporting();
            PageTitle = string.Format("Project Update Status for Reporting Year: {0}", reportingYear);
            ReportingYear = reportingYear;

            PeopleReceivingReminderGridDataUrl = peopleReceivingReminderGridDataUrl;
            PeopleReceivingReminderGridSpec = peopleReceivingReminderGridSpec;
            PeopleReceivingReminderGridName = "peopleReceivingAnReminderGrid";           
        }
    }
}