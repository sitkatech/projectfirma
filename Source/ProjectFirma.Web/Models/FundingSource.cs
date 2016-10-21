using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Areas.EIP.Controllers;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public partial class FundingSource : IAuditableEntity
    {
        public string EditUrl
        {
            get { return SitkaRoute<FundingSourceController>.BuildUrlFromExpression(t => t.Edit(FundingSourceID)); }
        }

        public string DeleteUrl
        {
            get { return SitkaRoute<FundingSourceController>.BuildUrlFromExpression(c => c.DeleteFundingSource(FundingSourceID)); }
        }

        public HtmlString DisplayNameAsUrl
        {
            get { return UrlTemplate.MakeHrefString(SummaryUrl, DisplayName); }
        }

        public string DisplayName
        {
            get { return string.Format("{0} ({1}){2}", FundingSourceName, Organization.AbbreviationIfAvailable, !IsActive ? " (Inactive)" : string.Empty); }
        }

        public string SummaryUrl
        {
            get { return SitkaRoute<FundingSourceController>.BuildUrlFromExpression(x => x.Summary(FundingSourceID)); }
        }

        public static bool IsFundingSourceNameUnique(IEnumerable<FundingSource> fundingSources, string fundingSourceName, int currentFundingSourceID)
        {
            var fundingSource =
                fundingSources.SingleOrDefault(x => x.FundingSourceID != currentFundingSourceID && String.Equals(x.FundingSourceName, fundingSourceName, StringComparison.InvariantCultureIgnoreCase));
            return fundingSource == null;
        }

        public int? ProjectsWhereYouAreTheFundingSourceMinCalendarYear
        {
            get { return ProjectFundingSourceExpenditures.Any() ? ProjectFundingSourceExpenditures.Min(x => x.CalendarYear) : (int?) null; }
        }

        public int? ProjectsWhereYouAreTheFundingSourceMaxCalendarYear
        {
            get { return ProjectFundingSourceExpenditures.Any() ? ProjectFundingSourceExpenditures.Max(x => x.CalendarYear) : (int?) null; }
        }

        public string AuditDescriptionString
        {
            get { return FundingSourceName; }
        }

        public List<Project> AssociatedProjects
        {
            get { return ProjectFundingSourceExpenditures.Select(x => x.Project).Distinct(new HavePrimaryKeyComparer<Project>()).OrderBy(x => x.DisplayName).ToList(); }
        }

        public IEnumerable<CalendarYearReportedValue> GetAllCalendarYearExpenditures()
        {
            return ProjectFundingSourceExpenditure.ToCalendarYearReportedValues(ProjectFundingSourceExpenditures);
        }

        public IEnumerable<CalendarYearReportedValue> GetReportableCalendarYearExpenditures()
        {
            return ProjectFundingSourceExpenditure.ToCalendarYearReportedValues(ProjectFundingSourceExpenditures.Where(exp => exp.Project.ProjectStage.AreExpendituresReportable()));
        }
    }
}