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

using System;
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
        public ViewGoogleChartViewData DustSuppressionPieChart { get; }
        public ViewGoogleChartViewData VegetationEnhancementPieChart { get; }
        public ViewGoogleChartViewData AquaticHabitatCreatedPieChart { get; }
        public ViewGoogleChartViewData EndangeredSpeciesHabitatCreatedPieChart { get; }
        public List<double> DustSuppressionValues { get; }
        public List<double> VegetationEnhancementValues { get; }
        public List<double> AquaticHabitatCreatedValues { get; }
        public List<double> EndangeredSpeciesHabitatCreatedValues { get; }
        public bool DustSuppressionHasData { get; }
        public bool VegetationEnhancementHasData { get; }
        public bool AquaticHabitatCreatedHasData { get; }
        public bool EndangeredSpeciesHabitatCreatedHasData { get; }
        public ViewGoogleChartViewData DustSuppressionColumnChart { get; }
        public Dictionary<string, Tuple<string, double>> DustSuppressionProjectToColorAndValue { get; }
        public ViewGoogleChartViewData VegetationEnhancementColumnChart { get; }
        public Dictionary<string, Tuple<string, double>> VegetationEnhancementProjectToColorAndValue { get; }
        public ViewGoogleChartViewData AquaticHabitatCreatedColumnChart { get; }
        public Dictionary<string, Tuple<string, double>> AquaticHabitatCreatedProjectToColorAndValue { get; }
        public ViewGoogleChartViewData EndangeredSpeciesHabitatCreatedColumnChart { get; }
        public Dictionary<string, Tuple<string, double>> EndangeredSpeciesHabitatCreatedProjectToColorAndValue { get; }

        public ProgressDashboardViewData(FirmaSession currentFirmaSession,
            ProjectFirmaModels.Models.FirmaPage firmaPage,
            int projectCount, decimal fundsCommittedToProgram, int partnershipCount, double communityEngagementCount,
            double totalAcresControlled,
            ProjectFirmaModels.Models.FirmaPage acresControlledIntroFirmaPage,
            GoogleChartJson dustSuppressionPieChart,
            GoogleChartJson vegetationEnhancementPieChart,
            GoogleChartJson aquaticHabitatCreatedPieChart,
            GoogleChartJson endangeredSpeciesHabitatCreatedPieChart,
            List<double> dustSuppressionValues,
            List<double> vegetationEnhancementValues,
            List<double> aquaticHabitatCreatedValues,
            List<double> endangeredSpeciesHabitatCreatedValues,
            List<GoogleChartJson> dustSuppressionColumnCharts,
            Dictionary<string, Tuple<string, double>> dustSuppressionProjectToColorAndValue,
            List<GoogleChartJson> vegetationEnhancementColumnCharts,
            Dictionary<string, Tuple<string, double>> vegetationEnhancementProjectToColorAndValue,
            List<GoogleChartJson> aquaticHabitatCreatedColumnCharts,
            Dictionary<string, Tuple<string, double>> aquaticHabitatCreatedProjectToColorAndValue,
            List<GoogleChartJson> endangeredSpeciesHabitatCreatedColumnCharts,
            Dictionary<string, Tuple<string, double>> endangeredSpeciesHabitatCreatedProjectToColorAndValue
            ) : base(currentFirmaSession, firmaPage)
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

            DustSuppressionPieChart = new ViewGoogleChartViewData(
                new List<GoogleChartJson> {dustSuppressionPieChart},
                dustSuppressionPieChart.GoogleChartConfiguration.Title, 366, true, true, true, false);
            VegetationEnhancementPieChart = new ViewGoogleChartViewData(
                new List<GoogleChartJson> {vegetationEnhancementPieChart},
                vegetationEnhancementPieChart.GoogleChartConfiguration.Title, 366, true, true, true,
                false);
            AquaticHabitatCreatedPieChart = new ViewGoogleChartViewData(
                new List<GoogleChartJson> {aquaticHabitatCreatedPieChart},
                aquaticHabitatCreatedPieChart.GoogleChartConfiguration.Title, 366, true, true, true, false);
            EndangeredSpeciesHabitatCreatedPieChart = new ViewGoogleChartViewData(
                new List<GoogleChartJson> { endangeredSpeciesHabitatCreatedPieChart },
                endangeredSpeciesHabitatCreatedPieChart.GoogleChartConfiguration.Title,
                endangeredSpeciesHabitatCreatedPieChart.ChartContainerID, 366, true, true, true, false);


            DustSuppressionValues = dustSuppressionValues;
            VegetationEnhancementValues = vegetationEnhancementValues;
            AquaticHabitatCreatedValues = aquaticHabitatCreatedValues;
            EndangeredSpeciesHabitatCreatedValues = endangeredSpeciesHabitatCreatedValues;

            DustSuppressionHasData = dustSuppressionValues.Any(x => x > 0);
            VegetationEnhancementHasData = vegetationEnhancementValues.Any(x => x > 0);
            AquaticHabitatCreatedHasData = aquaticHabitatCreatedValues.Any(x => x > 0);
            EndangeredSpeciesHabitatCreatedHasData = endangeredSpeciesHabitatCreatedValues.Any(x => x > 0);


            DustSuppressionColumnChart = new ViewGoogleChartViewData(dustSuppressionColumnCharts, "Completed Acres", "dustSuppressionAcresCompleted", 366, true, true, true, true);
            DustSuppressionProjectToColorAndValue = dustSuppressionProjectToColorAndValue;

            VegetationEnhancementColumnChart = new ViewGoogleChartViewData(vegetationEnhancementColumnCharts, "Completed Acres", "vegetationEnhancementAcresCompleted", 366, true, true, true, true);
            VegetationEnhancementProjectToColorAndValue = vegetationEnhancementProjectToColorAndValue;

            AquaticHabitatCreatedColumnChart = new ViewGoogleChartViewData(aquaticHabitatCreatedColumnCharts, "Completed Acres", "aquaticHabitatCreatedAcresCompleted", 366, true, true, true, true);
            AquaticHabitatCreatedProjectToColorAndValue = aquaticHabitatCreatedProjectToColorAndValue;

            EndangeredSpeciesHabitatCreatedColumnChart = new ViewGoogleChartViewData(endangeredSpeciesHabitatCreatedColumnCharts, "Completed Acres", "endangeredSpeciesHabitatCreatedAcresCompleted", 366, true, true, true, true);
            EndangeredSpeciesHabitatCreatedProjectToColorAndValue = endangeredSpeciesHabitatCreatedProjectToColorAndValue;
        }
    }
}