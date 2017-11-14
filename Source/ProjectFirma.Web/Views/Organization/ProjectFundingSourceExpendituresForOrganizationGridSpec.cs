using System;
using System.Collections.Generic;
using System.Globalization;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Project;

namespace ProjectFirma.Web.Views.Organization
{    
    public class ProjectFundingSourceExpendituresForOrganizationGridSpec : GridSpec<Models.ProjectFundingSourceExpenditure>
    {
        public ProjectFundingSourceExpendituresForOrganizationGridSpec(Models.Organization organization)
        {
            Add(Models.FieldDefinition.Project.ToGridHeaderString(),
                a => UrlTemplate.MakeHrefString(a.Project.GetDetailUrl(), a.Project.DisplayName),
                250,
                DhtmlxGridColumnFilterType.Html);
            Add(Models.FieldDefinition.ProjectStage.ToGridHeaderString(), x => x.Project.ProjectStage.ProjectStageDisplayName, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(Models.FieldDefinition.OrganizationType.ToGridHeaderString(), x => x.FundingSource.Organization.OrganizationType?.OrganizationTypeName, 80, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(Models.FieldDefinition.FundingSource.ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.FundingSource.SummaryUrl, x.FundingSource.DisplayName), 200);
            Add(Models.FieldDefinition.Organization.ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.FundingSource.Organization.GetDetailUrl(), x.FundingSource.Organization.DisplayName), 100);
            Add(string.Format("Provided by {0}", Models.FieldDefinition.Organization), x => (x.FundingSource.Organization == organization).ToYesOrEmpty(), 100, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add(string.Format("Received from other {0}", Models.FieldDefinition.Organization), x => (x.FundingSource.Organization != organization).ToYesOrEmpty(), 100, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add("Year", x => x.CalendarYear, 100, DhtmlxGridColumnFormatType.Date, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Amount", x => x.ExpenditureAmount, 100, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);            
        }
    }
}