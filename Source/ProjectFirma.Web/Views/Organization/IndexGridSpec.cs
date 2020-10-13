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

using System.Linq;
using System.Web;
using ProjectFirmaModels.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Organization
{
    public class IndexGridSpec : GridSpec<ProjectFirmaModels.Models.Organization>
    {
        public IndexGridSpec(FirmaSession currentFirmaSession, bool hasDeletePermissions)
        {
            var projectDictionary = HttpRequestStorage.DatabaseEntities.Projects.ToDictionary(x => x.ProjectID);
            var fundingSourceDictionary = HttpRequestStorage.DatabaseEntities.FundingSources
                .GroupBy(x => x.OrganizationID)
                .ToDictionary(x => x.Key, y => y.ToList());
            var projectFundingSourceExpenditureDictionary = HttpRequestStorage.DatabaseEntities.ProjectFundingSourceExpenditures
                .GroupBy(x => x.FundingSourceID)
                .ToDictionary(x => x.Key, y => y.ToList());
            var projectFundingSourceBudgetsDictionary = HttpRequestStorage.DatabaseEntities.ProjectFundingSourceBudgets
                .GroupBy(x => x.FundingSourceID)
                .ToDictionary(x => x.Key, y => y.ToList());
            var peopleDictionary = HttpRequestStorage.DatabaseEntities.People
                .GroupBy(x => x.OrganizationID)
                .ToDictionary(x => x.Key, y => y.ToList());

            if (hasDeletePermissions)
            {
                Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true), 30, DhtmlxGridColumnFilterType.None);
            }
            Add(FieldDefinitionEnum.Organization.ToType().ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.GetDetailUrl(), a.OrganizationName), 400, DhtmlxGridColumnFilterType.Html);
            Add("Short Name", a => a.OrganizationShortName, 100);
            Add(FieldDefinitionEnum.OrganizationType.ToType().ToGridHeaderString(), x => x.OrganizationType?.GetOrganizationTypeHtmlStringWithColor(), 100, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add(FieldDefinitionEnum.OrganizationPrimaryContact.ToType().ToGridHeaderString(), a => a.GetPrimaryContactPersonAsUrl(currentFirmaSession), 120);
            Add($"# of {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()} associated with this {FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()}", a => a.GetAllActiveProjects(fundingSourceDictionary, projectFundingSourceBudgetsDictionary, projectFundingSourceExpenditureDictionary, projectDictionary).Count, 90);
            if (currentFirmaSession.Person.CanViewProposals())
            {
                Add($"# of {FieldDefinitionEnum.Proposal.ToType().GetFieldDefinitionLabelPluralized()} associated with this {FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()}"
                    , a => a.GetProposalsVisibleToUser(currentFirmaSession, fundingSourceDictionary, projectFundingSourceBudgetsDictionary, projectFundingSourceExpenditureDictionary, projectDictionary).Count, 90);
            }
            Add($"# of {FieldDefinitionEnum.FundingSource.ToType().GetFieldDefinitionLabelPluralized()}", a => fundingSourceDictionary.ContainsKey(a.OrganizationID) ? fundingSourceDictionary[a.OrganizationID].Count : 0, 90);
            Add("# of Users", a =>
                peopleDictionary.ContainsKey(a.OrganizationID) ? peopleDictionary[a.OrganizationID].Count : 0, 90);
            Add("Is Active", a => a.IsActive.ToYesNo(), 80, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Has Spatial Boundary", x => (x.OrganizationBoundary != null).ToCheckboxImageOrEmptyForGrid(), 70, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            if (FirmaWebConfiguration.FeatureMatchMakerEnabled && MultiTenantHelpers.GetTenantAttributeFromCache().EnableMatchmaker)
            {
                Add("Matchmaker Service", a => a.GetOptInHasContentString(), 100, DhtmlxGridColumnFilterType.SelectFilterStrict);
            }
        }



        public enum OrganizationStatusFilterTypeEnum
        {
            ActiveOrganizations,
            AllOrganizations
        }
    }
}
