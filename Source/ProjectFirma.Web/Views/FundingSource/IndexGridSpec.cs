﻿/*-----------------------------------------------------------------------
<copyright file="IndexGridSpec.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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

using System.Collections.Generic;
using System.Linq;
using ProjectFirmaModels.Models;
using LtInfo.Common;
using LtInfo.Common.AgGridWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.FundingSource
{
    public class IndexGridSpec : GridSpec<ProjectFirmaModels.Models.FundingSource>
    {
        public IndexGridSpec(FirmaSession currentFirmaSession, List<ProjectFirmaModels.Models.FundingSourceCustomAttributeType> fundingSourceCustomAttributeTypes)
        {
            
            var projectFundingSourceBudgets = HttpRequestStorage.DatabaseEntities.ProjectFundingSourceBudgets
                .GroupBy(x => x.FundingSourceID)
                .ToDictionary(x => x.Key, y => y.ToList());
            var projectFundingSourceExpenditureDictionary = HttpRequestStorage.DatabaseEntities.ProjectFundingSourceExpenditures
                .GroupBy(x => x.FundingSourceID)
                .ToDictionary(x => x.Key, y => y.ToList());

            var fundingSourceCustomAttributeDictionary = HttpRequestStorage.DatabaseEntities.FundingSourceCustomAttributes
                .GroupBy(x => x.FundingSourceID)
                .ToDictionary(x => x.Key, y => y.ToList());
            var fundingSourceCustomAttributeValueDictionary = HttpRequestStorage.DatabaseEntities.FundingSourceCustomAttributeValues
                .GroupBy(x => x.FundingSourceCustomAttributeID)
                .ToDictionary(x => x.Key, y => y.ToList());
            var projectDictionary = HttpRequestStorage.DatabaseEntities.Projects.ToDictionary(x => x.ProjectID);
            var fundingSourceDeleteFeature = new FundingSourceDeleteFeature();
            if (fundingSourceDeleteFeature.HasPermissionByFirmaSession(currentFirmaSession))
            {
                Add("Delete", x => AgGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), fundingSourceDeleteFeature.HasPermission(currentFirmaSession, x).HasPermission, true), 30, AgGridColumnFilterType.None);
            }
            Add(FieldDefinitionEnum.FundingSource.ToType().ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.GetDetailUrl(), a.GetDisplayName()), 320, AgGridColumnFilterType.Html);
            Add(FieldDefinitionEnum.Organization.ToType().ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.Organization.GetDetailUrl(), a.Organization.GetDisplayName()), 300);
            Add(FieldDefinitionEnum.OrganizationType.ToType().ToGridHeaderString(), a => a.Organization.OrganizationType?.OrganizationTypeName, 80, AgGridColumnFilterType.SelectFilterStrict);
            Add("Description", a => a.FundingSourceDescription, 300);
            Add("Is Active", a => a.IsActive.ToYesNo(), 80, AgGridColumnFilterType.SelectFilterStrict);
            
            Add(FieldDefinitionEnum.FundingSourceAmount.ToType().ToGridHeaderString(), a => a.FundingSourceAmount, 80, AgGridColumnFormatType.Currency);

            if (MultiTenantHelpers.ReportFinancialsAtProjectLevel())
            {
                Add($"{FieldDefinitionEnum.NumberOfProjectsWithExpendedFunds.ToType().ToGridHeaderString()}", a => a.GetAssociatedProjects(currentFirmaSession, a.GetProjectFundingSourceExpendituresFromDictionary(projectFundingSourceExpenditureDictionary)).Count, 90);
                Add($"{FieldDefinitionEnum.TotalExpenditures.ToType().ToGridHeaderString()}", a => a.GetProjectFundingSourceExpendituresFromDictionary(projectFundingSourceExpenditureDictionary).Sum(x => x.ExpenditureAmount), 100, AgGridColumnFormatType.Currency);
                Add($"{FieldDefinitionEnum.NumberOfProjectsWithSecuredFunds.ToType().ToGridHeaderString()}"
                    , a => a.GetAssociatedProjectsWithSecuredFunding(currentFirmaSession, a.GetProjectFundingSourceBudgetsFromDictionary(projectFundingSourceBudgets), projectDictionary).Count
                    , 90);
                Add($"{FieldDefinitionEnum.TotalProjectSecuredFunds.ToType().ToGridHeaderString()}", a => a.GetProjectFundingSourceBudgetsFromDictionary(projectFundingSourceBudgets).Sum(x => x.SecuredAmount), 80, AgGridColumnFormatType.Currency);
                Add($"{FieldDefinitionEnum.TotalProjectTargetedFunds.ToType().ToGridHeaderString()}", a => a.GetProjectFundingSourceBudgetsFromDictionary(projectFundingSourceBudgets).Sum(x => x.TargetedAmount), 80, AgGridColumnFormatType.Currency);
            }

            foreach (var fundingSourceCustomAttributeType in fundingSourceCustomAttributeTypes.OrderBy(x => x.FundingSourceCustomAttributeTypeName))
            {
                if (fundingSourceCustomAttributeType.IncludeInFundingSourceGrid && fundingSourceCustomAttributeType.HasViewPermission(currentFirmaSession))
                {
                    Add($"{fundingSourceCustomAttributeType.FundingSourceCustomAttributeTypeName}"
                        , a => a.GetFundingSourceCustomAttributesValue(fundingSourceCustomAttributeType, fundingSourceCustomAttributeDictionary, fundingSourceCustomAttributeValueDictionary)
                        , 150, AgGridColumnFilterType.Text);
                }
            }
        }
    }
}
