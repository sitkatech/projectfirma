/*-----------------------------------------------------------------------
<copyright file="EditProjectViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.Shared.ProjectControls
{
    public class EditProjectViewData : FirmaUserControlViewData
    {
        public readonly IEnumerable<SelectListItem> TaxonomyTierOnes;
        public readonly IEnumerable<SelectListItem> StartYearRange;
        public readonly IEnumerable<SelectListItem> CompletionYearRange;
        public readonly IEnumerable<SelectListItem> ProjectStages;
        public readonly IEnumerable<SelectListItem> FundingTypes;
        public readonly IEnumerable<SelectListItem> Organizations;
        public readonly IEnumerable<SelectListItem> PrimaryContactPeople;
        public readonly Person DefaultPrimaryContactPerson;
        public readonly EditProjectType EditProjectType;
        public readonly string TaxonomyTierOneDisplayName;
        public readonly decimal? TotalExpenditures;
        public bool HasThreeTierTaxonomy { get; }

        public EditProjectViewData(EditProjectType editProjectType,
            string taxonomyTierOneDisplayName,
            IEnumerable<ProjectStage> projectStages,
            IEnumerable<FundingType> fundingTypes,
            IEnumerable<Models.Organization> organizations,
            IEnumerable<Person> primaryContactPeople,
            Person defaultPrimaryContactPerson,
            decimal? totalExpenditures,
            List<Models.TaxonomyTierOne> taxonomyTierOnes)
        {
            EditProjectType = editProjectType;
            TaxonomyTierOneDisplayName = taxonomyTierOneDisplayName;
            TotalExpenditures = totalExpenditures;
            ProjectStages = projectStages.OrderBy(x => x.SortOrder).ToSelectListWithEmptyFirstRow(x => x.ProjectStageID.ToString(CultureInfo.InvariantCulture), y => y.ProjectStageDisplayName);
            FundingTypes = fundingTypes.OrderBy(x => x.GetFundingTypeSortOrder()).ToSelectList(x => x.FundingTypeID.ToString(CultureInfo.InvariantCulture), y => y.GetFundingTypeDisplayName());
            Organizations = organizations.ToSelectListWithEmptyFirstRow(x => x.OrganizationID.ToString(CultureInfo.InvariantCulture), y => y.DisplayName);
            PrimaryContactPeople = primaryContactPeople.ToSelectListWithEmptyFirstRow(x => x.PersonID.ToString(CultureInfo.InvariantCulture), y => y.FullNameFirstLastAndOrgShortName,
                $"<Set Based on {Models.FieldDefinition.Project.GetFieldDefinitionLabel()}'s Associated {Models.FieldDefinition.Organization.GetFieldDefinitionLabelPluralized()}>");
            DefaultPrimaryContactPerson = defaultPrimaryContactPerson;
            TaxonomyTierOnes = taxonomyTierOnes.ToGroupedSelectList();
            StartYearRange = FirmaDateUtilities.YearsForUserInput().ToSelectListWithEmptyFirstRow(x => x.ToString(CultureInfo.InvariantCulture));
            CompletionYearRange = FirmaDateUtilities.YearsForUserInput().ToSelectListWithEmptyFirstRow(x => x.ToString(CultureInfo.InvariantCulture));
            HasThreeTierTaxonomy = MultiTenantHelpers.GetNumberOfTaxonomyTiers() == 3;
        }
    }
}
