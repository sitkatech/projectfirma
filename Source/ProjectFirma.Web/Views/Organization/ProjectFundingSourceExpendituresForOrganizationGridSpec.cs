﻿using System;
using System.Collections.Generic;
using System.Globalization;
using LtInfo.Common;
using LtInfo.Common.AgGridWrappers;
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
                AgGridColumnFilterType.Html);
            if (MultiTenantHelpers.HasCanStewardProjectsOrganizationRelationship())
            {
                Add(FieldDefinitionEnum.ProjectsStewardOrganizationRelationshipToProject.ToType().ToGridHeaderString(), x => x.Project.GetCanStewardProjectsOrganization().GetDisplayNameAsUrl(), 150,
                    AgGridColumnFilterType.Html);
            }
            Add(FieldDefinitionEnum.IsPrimaryContactOrganization.ToType().ToGridHeaderString(), x => x.Project.GetPrimaryContactOrganization().GetDisplayNameAsUrl(), 150, AgGridColumnFilterType.Html);
            Add(FieldDefinitionEnum.ProjectStage.ToType().ToGridHeaderString(), x => x.Project.ProjectStage.GetProjectStageDisplayName(), 90, AgGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.OrganizationType.ToType().ToGridHeaderString(), x => x.FundingSource.Organization.OrganizationType?.GetOrganizationTypeHtmlStringWithColor(), 80, AgGridColumnFilterType.SelectFilterHtmlStrict);
            Add(FieldDefinitionEnum.FundingSource.ToType().ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.FundingSource.GetDetailUrl(), x.FundingSource.GetDisplayName()), 120);
            Add(FieldDefinitionEnum.Organization.ToType().ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.FundingSource.Organization.GetDetailUrl(), x.FundingSource.Organization.GetDisplayName()), 120);
            Add($"Provided by {FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()}", x => (x.FundingSource.Organization == organization).ToYesOrEmpty(), 100, AgGridColumnFilterType.SelectFilterHtmlStrict);
            Add($"Received from other {FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()}", x => (x.FundingSource.Organization != organization).ToYesOrEmpty(), 100, AgGridColumnFilterType.SelectFilterHtmlStrict);
            Add(FieldDefinitionEnum.ReportingYear.ToType().ToGridHeaderString(), x => x.CalendarYear, 80, AgGridColumnFormatType.Date, AgGridColumnFilterType.SelectFilterStrict);
            Add("Amount", x => x.ExpenditureAmount, 80, AgGridColumnFormatType.Currency, AgGridColumnAggregationType.Total);
        }
    }
}