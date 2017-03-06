/*-----------------------------------------------------------------------
<copyright file="BasicsViewData.cs" company="Tahoe Regional Planning Agency">
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
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.ProposedProject
{
    public class BasicsViewData : ProposedProjectViewData
    {
        public IEnumerable<SelectListItem> TaxonomyTierOnes;
        public IEnumerable<SelectListItem> Organizations;
        public IEnumerable<SelectListItem> FundingTypes;
        public IEnumerable<SelectListItem> StartYearRange;
        public IEnumerable<SelectListItem> CompletionYearRange;

        public BasicsViewData(Person currentPerson, IEnumerable<Models.Organization> organizations, IEnumerable<FundingType> fundingTypes, IEnumerable<Models.TaxonomyTierOne> taxonomyTierOnes)
            : base(currentPerson, ProposedProjectSectionEnum.Basics)
        {
            AssignParameters(taxonomyTierOnes, organizations, fundingTypes);
        }

        public BasicsViewData(Person currentPerson,
            Models.ProposedProject proposedProject,
            ProposalSectionsStatus proposalSectionsStatus,
            IEnumerable<Models.Organization> organizations,
            IEnumerable<FundingType> fundingTypes, IEnumerable<Models.TaxonomyTierOne> taxonomyTierOnes)
            : base(currentPerson, proposedProject, ProposedProjectSectionEnum.Basics, proposalSectionsStatus)
        {
            AssignParameters(taxonomyTierOnes, organizations, fundingTypes);
        }

        private void AssignParameters(IEnumerable<Models.TaxonomyTierOne> taxonomyTierOnes, IEnumerable<Models.Organization> organizations, IEnumerable<FundingType> fundingTypes)
        {
            TaxonomyTierOnes = taxonomyTierOnes.ToList().OrderBy(ap => ap.DisplayName).ToList().ToGroupedSelectList();
            Organizations = organizations.ToSelectListWithEmptyFirstRow(x => x.OrganizationID.ToString(CultureInfo.InvariantCulture), y => y.DisplayName);

            FundingTypes = fundingTypes.ToSelectList(x => x.FundingTypeID.ToString(CultureInfo.InvariantCulture), y => y.FundingTypeDisplayName);
            StartYearRange =
                FirmaDateUtilities.GetRangeOfYears(FirmaDateUtilities.MinimumYear, DateTime.Now.Year + FirmaDateUtilities.YearsBeyondPresentForMaximumYearForUserInput)
                    .ToSelectListWithEmptyFirstRow(x => x.ToString(CultureInfo.InvariantCulture));
            CompletionYearRange = FirmaDateUtilities.FutureYearsForUserInput().ToSelectListWithEmptyFirstRow(x => x.ToString(CultureInfo.InvariantCulture));
        }
    }
}
