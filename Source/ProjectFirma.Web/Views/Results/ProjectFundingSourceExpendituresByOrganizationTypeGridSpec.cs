/*-----------------------------------------------------------------------
<copyright file="ProjectFundingSourceExpendituresByOrganizationTypeGridSpec.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using System.Globalization;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.Results
{
    public class ProjectFundingSourceExpendituresByOrganizationTypeGridSpec : GridSpec<ProjectFundingSourceOrganizationTypeExpenditure>
    {
        public ProjectFundingSourceExpendituresByOrganizationTypeGridSpec(int? calendarYear)
        {            
            Add(Models.FieldDefinition.ProjectName.ToGridHeaderString(),
                x => UrlTemplate.MakeHrefString(x.Project.GetDetailUrl(), x.Project.ProjectName),
                200,
                DhtmlxGridColumnFilterType.Html);
            Add(Models.FieldDefinition.TaxonomyTierThree.ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.Project.TaxonomyLeaf.TaxonomyTierTwo.TaxonomyTierThree.SummaryUrl, x.Project.TaxonomyLeaf.TaxonomyTierTwo.TaxonomyTierThree.DisplayName), 150);
            Add(Models.FieldDefinition.TaxonomyTierTwo.ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.Project.TaxonomyLeaf.TaxonomyTierTwo.SummaryUrl, x.Project.TaxonomyLeaf.TaxonomyTierTwo.DisplayName), 100);
            Add(Models.FieldDefinition.ProjectStage.ToGridHeaderString(), x => x.Project.ProjectStage.ProjectStageDisplayName, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(Models.FieldDefinition.OrganizationType.ToGridHeaderString(), x => x.FundingSource.Organization.OrganizationType?.OrganizationTypeName, 80, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(Models.FieldDefinition.FundingSource.ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.FundingSource.SummaryUrl, x.FundingSource.DisplayName), 200);
            Add(Models.FieldDefinition.Organization.ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.FundingSource.Organization.GetDetailUrl(), x.FundingSource.Organization.DisplayName), 100);
            Add($"{Models.FieldDefinition.FundedAmount.ToGridHeaderString()} ({calendarYear?.ToString(CultureInfo.InvariantCulture) ?? "Recent Years"})", x => x.ExpenditureAmount, 100, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
        }
    }
}
