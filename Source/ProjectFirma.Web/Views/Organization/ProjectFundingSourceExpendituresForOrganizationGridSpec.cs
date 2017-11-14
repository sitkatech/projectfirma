using System;
using System.Collections.Generic;
using System.Globalization;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
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
            if (MultiTenantHelpers.HasCanStewardProjectsOrganizationRelationship())
            {
                Add(Models.FieldDefinition.CanStewardProjectsOrganization.ToGridHeaderString(), x => x.Project.GetCanStewardProjectsOrganization().GetDisplayNameAsUrl(), 150,
                    DhtmlxGridColumnFilterType.Html);
            }
            Add(Models.FieldDefinition.IsPrimaryContactOrganization.ToGridHeaderString(), x => x.Project.GetPrimaryContactOrganization().GetDisplayNameAsUrl(), 150, DhtmlxGridColumnFilterType.Html);
            Add(Models.FieldDefinition.ProjectStage.ToGridHeaderString(), x => x.Project.ProjectStage.ProjectStageDisplayName, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(Models.FieldDefinition.OrganizationType.ToGridHeaderString(), x => x.FundingSource.Organization.OrganizationType?.OrganizationTypeName, 80, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(Models.FieldDefinition.FundingSource.ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.FundingSource.SummaryUrl, x.FundingSource.DisplayName), 120);
            Add(Models.FieldDefinition.Organization.ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.FundingSource.Organization.GetDetailUrl(), x.FundingSource.Organization.DisplayName), 120);
            Add($"Provided by {Models.FieldDefinition.Organization.GetFieldDefinitionLabel()}", x => (x.FundingSource.Organization == organization).ToYesOrEmpty(), 100, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add($"Received from other {Models.FieldDefinition.Organization.GetFieldDefinitionLabel()}", x => (x.FundingSource.Organization != organization).ToYesOrEmpty(), 100, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add("Year", x => x.CalendarYear, 80, DhtmlxGridColumnFormatType.Date, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Amount", x => x.ExpenditureAmount, 80, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);            
        }
    }
}