using System;
using System.Collections.Generic;
using System.Globalization;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views.Project;

namespace ProjectFirma.Web.Views.Organization
{    
    public class ProjectFundingSourceExpendituresForOrganizationGridSpec : GridSpec<ProjectFirmaModels.Models.ProjectFundingSourceExpenditure>
    {
        public ProjectFundingSourceExpendituresForOrganizationGridSpec(ProjectFirmaModels.Models.Organization organization)
        {
            Add(FieldDefinitionEnum.Project.ToType().ToGridHeaderString(),
                a => UrlTemplate.MakeHrefString(a.Project.GetDetailUrl(), a.Project.GetDisplayName()),
                250,
                DhtmlxGridColumnFilterType.Html);
            if (MultiTenantHelpers.HasCanStewardProjectsOrganizationRelationship())
            {
                Add(FieldDefinitionEnum.ProjectsStewardOrganizationRelationshipToProject.ToType().ToGridHeaderString(), x => x.Project.GetCanStewardProjectsOrganization().GetDisplayNameAsUrl(), 150,
                    DhtmlxGridColumnFilterType.Html);
            }
            Add(FieldDefinitionEnum.IsPrimaryContactOrganization.ToType().ToGridHeaderString(), x => x.Project.GetPrimaryContactOrganization().GetDisplayNameAsUrl(), 150, DhtmlxGridColumnFilterType.Html);
            Add(FieldDefinitionEnum.ProjectStage.ToType().ToGridHeaderString(), x => x.Project.ProjectStage.ProjectStageDisplayName, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.OrganizationType.ToType().ToGridHeaderString(), x => x.FundingSource.Organization.OrganizationType?.OrganizationTypeName, 80, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.FundingSource.ToType().ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.FundingSource.GetDetailUrl(), x.FundingSource.GetDisplayName()), 120);
            Add(FieldDefinitionEnum.Organization.ToType().ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.FundingSource.Organization.GetDetailUrl(), x.FundingSource.Organization.GetDisplayName()), 120);
            Add($"Provided by {FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()}", x => (x.FundingSource.Organization == organization).ToYesOrEmpty(), 100, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add($"Received from other {FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()}", x => (x.FundingSource.Organization != organization).ToYesOrEmpty(), 100, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add(FieldDefinitionEnum.ReportingYear.ToType().ToGridHeaderString(), x => x.CalendarYear, 80, DhtmlxGridColumnFormatType.Date, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Amount", x => x.ExpenditureAmount, 80, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
        }
    }
}