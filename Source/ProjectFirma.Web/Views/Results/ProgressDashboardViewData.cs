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

using System.Collections.Generic;
using System.Linq;
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
        public ViewGoogleChartViewData DustSuppressionViewGoogleChartViewData { get; }
        public ViewGoogleChartViewData VegetationEnhancementViewGoogleChartViewData { get; }
        public ViewGoogleChartViewData AquaticHabitatCreatedViewGoogleChartViewData { get; }
        public ViewGoogleChartViewData EndangeredSpeciesHabitatCreatedViewGoogleChartViewData { get; }
        public List<double> DustSuppressionValues { get; }
        public List<double> VegetationEnhancementValues { get; }
        public List<double> AquaticHabitatCreatedValues { get; }
        public List<double> EndangeredSpeciesHabitatCreatedValues { get; }
        public bool DustSuppressionHasData { get; }
        public bool VegetationEnhancementHasData { get; }
        public bool AquaticHabitatCreatedHasData { get; }
        public bool EndangeredSpeciesHabitatCreatedHasData { get; }


        public ProgressDashboardViewData(FirmaSession currentFirmaSession,
            ProjectFirmaModels.Models.FirmaPage firmaPage,
            int projectCount, decimal fundsCommittedToProgram, int partnershipCount, double communityEngagementCount,
            double totalAcresControlled,
            ProjectFirmaModels.Models.FirmaPage acresControlledIntroFirmaPage,
            GoogleChartJson areaTreatedForDustSuppressionGoogleChart,
            GoogleChartJson areaTreatedForVegetationEnhancementGoogleChart,
            GoogleChartJson aquaticHabitatCreatedGoogleChart,
            GoogleChartJson endangeredSpeciesHabitatCreatedGoogleChart,
            List<double> dustSuppressionValues,
            List<double> vegetationEnhancementValues,
            List<double> aquaticHabitatCreatedValues,
            List<double> endangeredSpeciesHabitatCreatedValues) : base(currentFirmaSession, firmaPage)
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

            AreaTreatedForDustSuppression = dustSuppressionValues[0];
            AreaTreatedForVegetationEnhancement = vegetationEnhancementValues[0];
            AquaticHabitatCreated = aquaticHabitatCreatedValues[0];
            EndangeredSpeciesHabitatCreated = endangeredSpeciesHabitatCreatedValues[0];

            AcresControlledIntroViewPageContentViewData = new ViewPageContentViewData(acresControlledIntroFirmaPage, currentFirmaSession);

            DustSuppressionViewGoogleChartViewData = new ViewGoogleChartViewData(areaTreatedForDustSuppressionGoogleChart, areaTreatedForDustSuppressionGoogleChart.GoogleChartConfiguration.Title, 366, true, true, true);
            
            
            VegetationEnhancementViewGoogleChartViewData = new ViewGoogleChartViewData(areaTreatedForVegetationEnhancementGoogleChart, areaTreatedForVegetationEnhancementGoogleChart.GoogleChartConfiguration.Title, 366, true, true, true);
            AquaticHabitatCreatedViewGoogleChartViewData = new ViewGoogleChartViewData(aquaticHabitatCreatedGoogleChart, aquaticHabitatCreatedGoogleChart.GoogleChartConfiguration.Title, 366, true, true, true);
            EndangeredSpeciesHabitatCreatedViewGoogleChartViewData = new ViewGoogleChartViewData(
                endangeredSpeciesHabitatCreatedGoogleChart,
                endangeredSpeciesHabitatCreatedGoogleChart.GoogleChartConfiguration.Title,
                endangeredSpeciesHabitatCreatedGoogleChart.ChartContainerID, 366, true, true, true);


            DustSuppressionValues = dustSuppressionValues;
            VegetationEnhancementValues = vegetationEnhancementValues;
            AquaticHabitatCreatedValues = aquaticHabitatCreatedValues;
            EndangeredSpeciesHabitatCreatedValues = endangeredSpeciesHabitatCreatedValues;

            DustSuppressionHasData = dustSuppressionValues.Any(x => x > 0);
            VegetationEnhancementHasData = vegetationEnhancementValues.Any(x => x > 0);
            AquaticHabitatCreatedHasData = aquaticHabitatCreatedValues.Any(x => x > 0);
            EndangeredSpeciesHabitatCreatedHasData = endangeredSpeciesHabitatCreatedValues.Any(x => x > 0);

        }
    }
}