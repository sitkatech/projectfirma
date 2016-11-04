using System.Collections.Generic;
using System.Globalization;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Project;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.FundingSource
{
    public class ProjectCalendarYearExpendituresGridSpec : GridSpec<ProjectCalendarYearExpenditure>
    {
        public ProjectCalendarYearExpendituresGridSpec(IEnumerable<int> calendarYearsForProjectExpenditures)
        {
            Add(Models.FieldDefinition.Project.ToGridHeaderString(),
                a => UrlTemplate.MakeHrefString(a.Project.GetSummaryUrl(), a.Project.DisplayName),
                350,
                DhtmlxGridColumnFilterType.Html);
            Add(Models.FieldDefinition.ProjectStage.ToGridHeaderStringWider(), x => x.Project.ProjectStage.ProjectStageDisplayName, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            foreach (var year in calendarYearsForProjectExpenditures)
            {
                var calendarYear = year;
                Add(calendarYear.ToString(CultureInfo.InvariantCulture), a => a.CalendarYearExpenditure[calendarYear], 100, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            }
        }
    }
}