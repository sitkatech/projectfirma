using System.Collections.Generic;
using ProjectFirma.Web.Areas.EIP.Views.Project;
using LtInfo.Common.ExcelWorkbookUtilities;

namespace ProjectFirma.Web.Areas.EIP.Views.Results
{
    public class FundingSourceCalendarYearExpenditureExcelSpec : ExcelWorksheetSpec<FundingSourceCalendarYearExpenditure>
    {
        public FundingSourceCalendarYearExpenditureExcelSpec(Dictionary<int, string> calendarYears)
        {
            AddColumn(Models.FieldDefinition.Organization.FieldDefinitionDisplayName, x => x.OrganizationName);
            AddColumn(Models.FieldDefinition.FundingSource.FieldDefinitionDisplayName, x => x.FundingSourceName);
            foreach (var calendarYear in calendarYears)
            {
                var currentCalendarYear = calendarYear;
                AddColumn(calendarYear.Value, x => x.CalendarYearExpenditure[currentCalendarYear.Key]);
            }
        }
    }
}