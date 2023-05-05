/*-----------------------------------------------------------------------
<copyright file="ProgressDashboardViewData.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

using ProjectFirma.Web.Common;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Results
{
    public class ProgressDashboardViewData : FirmaViewData
    {
        public int ProjectCount { get; }
        public decimal FundsCommittedToProgram { get; }
        public int PartnershipCount { get; }
        public double CommunityEngagementCount { get; }

        public double TotalAcresControlled { get; }
        public int AcresControlledTarget { get; }
        public double AcresControlledPercent { get; }
        public double AreaTreatedForDustSuppression { get; }
        public double AreaTreatedForVegetationEnhancement { get; }
        public double AquaticHabitatCreated { get; }
        public double EndangeredSpeciesHabitatCreated { get; }
        public ViewPageContentViewData AcresControlledIntroViewPageContentViewData { get; }

        public ProgressDashboardViewData(FirmaSession currentFirmaSession,
            ProjectFirmaModels.Models.FirmaPage firmaPage,
            int projectCount, decimal fundsCommittedToProgram, int partnershipCount, double communityEngagementCount,
            double totalAcresControlled, double areaTreatedForDustSuppression, double areaTreatedForVegetationEnhancement,
            double aquaticHabitatCreated, double endangeredSpeciesHabitatCreated,
            ProjectFirmaModels.Models.FirmaPage acresControlledIntroFirmaPage) : base(currentFirmaSession, firmaPage)
        {
            PageTitle = "Progress Overview";
            // progress overview
            ProjectCount = projectCount;
            FundsCommittedToProgram = fundsCommittedToProgram;
            PartnershipCount = partnershipCount;
            CommunityEngagementCount = communityEngagementCount;
            
            // acres controlled
            TotalAcresControlled = totalAcresControlled;
            AcresControlledTarget = FirmaWebConfiguration.SSMPAcresControlledTarget;
            AcresControlledPercent = totalAcresControlled / AcresControlledTarget * 100;

            AreaTreatedForDustSuppression = areaTreatedForDustSuppression;
            AreaTreatedForVegetationEnhancement = areaTreatedForVegetationEnhancement;
            AquaticHabitatCreated = aquaticHabitatCreated;
            EndangeredSpeciesHabitatCreated = endangeredSpeciesHabitatCreated;

            AcresControlledIntroViewPageContentViewData = new ViewPageContentViewData(acresControlledIntroFirmaPage, currentFirmaSession);
        }
    }
}