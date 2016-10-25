using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using LtInfo.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectFundingSourceExpenditure : IAuditableEntity, IFundingSourceExpenditure
    {
        public decimal? MonetaryAmount
        {
            get { return ExpenditureAmount; }
        }

        public string ExpenditureAmountDisplay
        {
            get { return ExpenditureAmount.ToStringCurrency(); }
        }

        public string AuditDescriptionString
        {
            get
            {
                var project = HttpRequestStorage.DatabaseEntities.Projects.Find(ProjectID);
                var fundingSource = HttpRequestStorage.DatabaseEntities.FundingSources.Find(FundingSourceID);
                var projectName = project != null ? project.AuditDescriptionString : ViewUtilities.NotFoundString;
                var fundingSourceName = fundingSource != null ? fundingSource.AuditDescriptionString : ViewUtilities.NotFoundString;
                var expenditureAmount = ExpenditureAmountDisplay;
                return String.Format("Project: {0}, Funding Source: {1}, Year: {2},  Expenditure: {3}", projectName, fundingSourceName, CalendarYear, expenditureAmount);
            }
        }

        public static IEnumerable<CalendarYearReportedValue> ToCalendarYearReportedValues(IEnumerable<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures)
        {
            var yearRange = FirmaDateUtilities.GetRangeOfYearsForReporting();
            return yearRange.OrderBy(cy => cy).Select(cy =>
            {
                var pmavForThisCalendaYear = projectFundingSourceExpenditures.Where(x => x.CalendarYear == cy).ToList();
                return new CalendarYearReportedValue(cy, pmavForThisCalendaYear.Any() ? (double?) pmavForThisCalendaYear.Sum(y => y.ExpenditureAmount) : null);
            });
        }
    }
}