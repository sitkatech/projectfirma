/*-----------------------------------------------------------------------
<copyright file="EditProjectViewData.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using LtInfo.Common.Views;

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
        public readonly EditProjectType EditProjectType;
        public readonly string TaxonomyTierOneDisplayName;
        public readonly decimal? TotalExpenditures;
        public readonly bool HasExistingProjectBudgetUpdates;
        public readonly string LeadImplementerPrimaryContact;

        public EditProjectViewData(EditProjectType editProjectType,
            string taxonomyTierOneDisplayName,
            IEnumerable<ProjectStage> projectStages,
            IEnumerable<FundingType> fundingTypes,
            IEnumerable<Models.Organization> organizations,
            IEnumerable<Person> primaryContactPeople,
            decimal? totalExpenditures,
            bool hasExistingProjectBudgetUpdates,
            List<Models.TaxonomyTierOne> taxonomyTierOnes, Models.Organization leadImplementer)
        {
            EditProjectType = editProjectType;
            TaxonomyTierOneDisplayName = taxonomyTierOneDisplayName;
            TotalExpenditures = totalExpenditures;
            ProjectStages = projectStages.OrderBy(x => x.SortOrder).ToSelectListWithEmptyFirstRow(x => x.ProjectStageID.ToString(CultureInfo.InvariantCulture), y => y.ProjectStageDisplayName);
            FundingTypes = fundingTypes.OrderBy(x => x.SortOrder).ToSelectList(x => x.FundingTypeID.ToString(CultureInfo.InvariantCulture), y => y.FundingTypeDisplayName);
            Organizations = organizations.ToSelectListWithEmptyFirstRow(x => x.OrganizationID.ToString(CultureInfo.InvariantCulture), y => y.DisplayName);
            PrimaryContactPeople = primaryContactPeople.ToSelectListWithEmptyFirstRow(x => x.OrganizationID.ToString(CultureInfo.InvariantCulture), y => y.FullNameFirstLastAndOrg);
            TaxonomyTierOnes = taxonomyTierOnes.ToGroupedSelectList();
            StartYearRange = FirmaDateUtilities.YearsForUserInput().ToSelectListWithEmptyFirstRow(x => x.ToString(CultureInfo.InvariantCulture));
            CompletionYearRange = FirmaDateUtilities.YearsForUserInput().ToSelectListWithEmptyFirstRow(x => x.ToString(CultureInfo.InvariantCulture));
            HasExistingProjectBudgetUpdates = hasExistingProjectBudgetUpdates;
            LeadImplementerPrimaryContact = leadImplementer?.PrimaryContactPerson != null ? leadImplementer.PrimaryContactPerson.FullNameFirstLastAndOrg : ViewUtilities.NoneString;
        }
    }
}
