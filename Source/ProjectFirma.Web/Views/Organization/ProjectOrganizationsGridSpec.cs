using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.Organization
{
    public class ProjectOrganizationsGridSpec : GridSpec<ProjectImplementingOrganizationOrProjectFundingOrganization>
    {
        public ProjectOrganizationsGridSpec(IEnumerable<int> calendarYearsForProjectExpenditures)
        {
            Add(Models.FieldDefinition.Project.ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.Project.GetDetailUrl(), a.Project.DisplayName), 350, DhtmlxGridColumnFilterType.Html);
            Add(Models.FieldDefinition.ProjectStage.ToGridHeaderStringWider(), a => a.Project.ProjectStage.ProjectStageDisplayName, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(Models.FieldDefinition.LeadImplementer.ToGridHeaderString(), a => a.IsLeadOrganization.ToYesNo(), 120, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(Models.FieldDefinition.Implementer.ToGridHeaderString(), a => (a.IsImplementingOrganization && !a.IsLeadOrganization).ToYesNo(), 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(Models.FieldDefinition.Funder.ToGridHeaderString(), a => a.IsFundingOrganization.ToYesNo(), 60, DhtmlxGridColumnFilterType.SelectFilterStrict);
            foreach (var year in calendarYearsForProjectExpenditures)
            {
                var calendarYear = year;
                Add(calendarYear.ToString(CultureInfo.InvariantCulture),
                    a =>
                        a.Organization.FundingSources.SelectMany(x => x.ProjectFundingSourceExpenditures.Where(pfse => pfse.CalendarYear == calendarYear && pfse.ProjectID == a.Project.ProjectID))
                            .Sum(pfse => pfse.ExpenditureAmount),
                    100,
                    DhtmlxGridColumnFormatType.Currency,
                    DhtmlxGridColumnAggregationType.Total);
            }
        }
    }
}