/*-----------------------------------------------------------------------
<copyright file="IndexGridSpec.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using System.Collections.Generic;
using System.Linq;
using ProjectFirmaModels.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
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
            var currentPerson = currentFirmaSession.Person;

            var fundingSourceDeleteFeature = new FundingSourceDeleteFeature();
            if (fundingSourceDeleteFeature.HasPermissionByFirmaSession(currentFirmaSession))
            {
                Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), fundingSourceDeleteFeature.HasPermission(currentFirmaSession, x).HasPermission, true), 30, DhtmlxGridColumnFilterType.None);
            }
            Add(FieldDefinitionEnum.FundingSource.ToType().ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.GetDetailUrl(), a.GetDisplayName()), 320, DhtmlxGridColumnFilterType.Html);
            Add(FieldDefinitionEnum.Organization.ToType().ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.Organization.GetDetailUrl(), a.Organization.GetDisplayName()), 300);
            Add(FieldDefinitionEnum.OrganizationType.ToType().ToGridHeaderString(), a => a.Organization.OrganizationType?.OrganizationTypeName, 80, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Description", a => a.FundingSourceDescription, 300);
            Add("Is Active", a => a.IsActive.ToYesNo(), 80, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.FundingSourceAmount.ToType().ToGridHeaderString(), a => a.FundingSourceAmount, 80, DhtmlxGridColumnFormatType.Currency);
            Add($"{FieldDefinitionEnum.NumberOfProjectsWithExpendedFunds.ToType().ToGridHeaderString()}", a => a.GetAssociatedProjects(currentPerson).Count, 90);
            Add($"{FieldDefinitionEnum.TotalExpenditures.ToType().ToGridHeaderString()}", a => a.ProjectFundingSourceExpenditures.Sum(x => x.ExpenditureAmount), 100, DhtmlxGridColumnFormatType.Currency);
            Add($"{FieldDefinitionEnum.NumberOfProjectsWithSecuredFunds.ToType().ToGridHeaderString()}", a => a.GetAssociatedProjectsWithSecuredFunding(currentPerson).Count, 90);
            Add($"{FieldDefinitionEnum.TotalProjectSecuredFunds.ToType().ToGridHeaderString()}", a => a.ProjectFundingSourceBudgets.Sum(x => x.SecuredAmount), 80, DhtmlxGridColumnFormatType.Currency);
            Add($"{FieldDefinitionEnum.TotalProjectTargetedFunds.ToType().ToGridHeaderString()}", a => a.ProjectFundingSourceBudgets.Sum(x => x.TargetedAmount), 80, DhtmlxGridColumnFormatType.Currency);
            foreach (var fundingSourceCustomAttributeType in fundingSourceCustomAttributeTypes.OrderBy(x => x.FundingSourceCustomAttributeTypeName))
            {
                if (fundingSourceCustomAttributeType.IncludeInFundingSourceGrid && fundingSourceCustomAttributeType.HasViewPermission(currentFirmaSession))
                {
                    Add($"{fundingSourceCustomAttributeType.FundingSourceCustomAttributeTypeName}", a => a.GetFundingSourceCustomAttributesValue(fundingSourceCustomAttributeType), 150, DhtmlxGridColumnFilterType.Text);
                }
            }
        }
    }
}
