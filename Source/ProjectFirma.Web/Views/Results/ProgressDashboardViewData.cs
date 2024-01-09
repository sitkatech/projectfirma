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
        public double TotalAcres { get; }
        public double TotalAcresInPlanning { get; }
        public double TotalAcresInConstruction { get; }
        public double TotalAcresCompleted { get; }
        public int AcresTarget { get; }
        public int DustSuppressionAcresTarget { get; }
        public int FishAndWildlifeHabitatAcresTarget { get; }
        public double AcresInPlanningPercent { get; }
        public double AcresInConstructionPercent { get; }
        public double AcresCompletedPercent { get; }
        public double AreaTreatedForDustSuppression { get; }
        public double FishAndWildlifeHabitatAcresCounted { get; }
        
        public ViewPageContentViewData AcresConstructedByTheNumbersViewPageContentViewData { get; }
        public ViewPageContentViewData DustSuppressionViewPageContentViewData { get; }
        public ViewPageContentViewData FishAndWildlifeHabitatViewPageContentViewData { get; }
        public ViewGoogleChartViewData DustSuppressionPieChart { get; }
        public ViewGoogleChartViewData FishAndWildlifeHabitatAcresCountedPieChart { get; }
        public List<double> DustSuppressionValues { get; }
        public List<double> FishAndWildlifeHabitatAcresCountedValues { get; }
        public bool DustSuppressionHasData { get; }
        public bool FishAndWildlifeHabitatAcresCountedHasData { get; }
        public ViewGoogleChartViewData DustSuppressionColumnChart { get; }
        public Dictionary<ProjectFirmaModels.Models.Project, Tuple<string, double>> DustSuppressionProjectToColorAndValue { get; }
        public ViewGoogleChartViewData FishAndWildlifeHabitatAcresCountedColumnChart { get; }
        public Dictionary<ProjectFirmaModels.Models.Project, Tuple<string, double>> FishAndWildlifeHabitatAcresCountedProjectToColorAndValue { get; }
        public ProjectFirmaModels.Models.PerformanceMeasure DustSuppressionPerformanceMeasure { get; }
        public ProjectFirmaModels.Models.PerformanceMeasure FishAndWildlifeHabitatAcresCountedPerformanceMeasure { get; }
        public ProjectFirmaModels.Models.PerformanceMeasure EndangeredSpeciesHabitatPerformanceMeasure { get; }
        public ProjectFirmaModels.Models.PerformanceMeasure PublicAmenitiesAndRecreationAccessPerformanceMeasure { get; }
        public ProjectFirmaModels.Models.PerformanceMeasure GrassBalesPlacedPerformanceMeasure { get; }
        public ProjectFirmaModels.Models.PerformanceMeasure StormwaterSpreadingAreasCreatedPerformanceMeasure { get; }
        public ProjectFirmaModels.Models.PerformanceMeasure SurfaceRougheningConductedPerformanceMeasure { get; }
        public ProjectFirmaModels.Models.PerformanceMeasure VegetationEnhancementConductedPerformanceMeasure { get; }
        public ProjectFirmaModels.Models.PerformanceMeasure AquaticHabitatCreatedPerformanceMeasure { get; }
        public ProjectFirmaModels.Models.PerformanceMeasure WetlandHabitatCreatedPerformanceMeasure { get; }
        public double EndangeredSpeciesHabitatCreatedCount { get; }
        public double PublicAmenitiesAndRecreationAccessCount { get; }
        public double GrassBalesPlacedCount { get; }
        public double StormwaterSpreadingAreasCreatedCount { get; }
        public double SurfaceRougheningConductedCount { get; }
        public double VegetationEnhancementConductedCount { get; }
        public double AquaticHabitatCreatedCount { get; }
        public double WetlandHabitatCreatedCount { get; }

        public ProgressDashboardViewData(FirmaSession currentFirmaSession,
            ProjectFirmaModels.Models.FirmaPage firmaPage,
            int projectCount, decimal fundsCommittedToProgram, int partnershipCount,
            ProjectFirmaModels.Models.FirmaPage acresConstructedByTheNumbersFirmaPage,
            ProjectFirmaModels.Models.FirmaPage dustSuppressionFirmaPage,
            ProjectFirmaModels.Models.FirmaPage fishAndWildlifeHabitatFirmaPage,
            GoogleChartJson dustSuppressionPieChart,
            GoogleChartJson fishAndWildlifeHabitatAcresCountedPieChart,
            List<double> dustSuppressionValues,
            List<double> fishAndWildlifeHabitatAcresCountedValues,
            List<GoogleChartJson> dustSuppressionColumnCharts,
            Dictionary<ProjectFirmaModels.Models.Project, Tuple<string, double>> dustSuppressionProjectToColorAndValue,
            List<GoogleChartJson> fishAndWildlifeHabitatAcresCountedColumnCharts,
            Dictionary<ProjectFirmaModels.Models.Project, Tuple<string, double>> fishAndWildlifeHabitatAcresCountedProjectToColorAndValue,
            ProjectFirmaModels.Models.PerformanceMeasure dustSuppressionPerformanceMeasure,
            ProjectFirmaModels.Models.PerformanceMeasure fishAndWildlifeHabitatAcresCountedPerformanceMeasure,
            ProjectFirmaModels.Models.PerformanceMeasure endangeredSpeciesHabitatPerformanceMeasure,
            ProjectFirmaModels.Models.PerformanceMeasure publicAmenitiesAndRecreationAccessPerformanceMeasure,
            ProjectFirmaModels.Models.PerformanceMeasure grassBalesPlacedPerformanceMeasure,
            ProjectFirmaModels.Models.PerformanceMeasure stormwaterSpreadingAreasCreatedPerformanceMeasure,
            ProjectFirmaModels.Models.PerformanceMeasure surfaceRougheningConductedPerformanceMeasure,
            ProjectFirmaModels.Models.PerformanceMeasure vegetationEnhancementConductedPerformanceMeasure,
            ProjectFirmaModels.Models.PerformanceMeasure aquaticHabitatCreatedPerformanceMeasure,
            ProjectFirmaModels.Models.PerformanceMeasure wetlandHabitatCreatedPerformanceMeasure,
            double endangeredSpeciesHabitatCreatedCount,
            double publicAmenitiesAndRecreationAccessCount,
            double grassBalesPlacedCount,
            double stormwaterSpreadingAreasCreatedCount,
            double surfaceRougheningConductedCount,
            double vegetationEnhancementConductedCount,
            double aquaticHabitatCreatedCount,
            double wetlandHabitatCreatedCount
            ) : base(currentFirmaSession, firmaPage)
        {
            BreadCrumbTitle = "Progress Dashboard";
            ContainerFluid = true;
            // progress overview
            ProjectCount = projectCount;
            FundsCommittedToProgram = fundsCommittedToProgram;
            PartnershipCount = partnershipCount;
            
            // acres controlled
            TotalAcres = dustSuppressionValues.Sum() + fishAndWildlifeHabitatAcresCountedValues.Sum();
            TotalAcresInPlanning = dustSuppressionValues[2] + fishAndWildlifeHabitatAcresCountedValues[2];
            TotalAcresInConstruction = dustSuppressionValues[1] + fishAndWildlifeHabitatAcresCountedValues[1];
            TotalAcresCompleted = dustSuppressionValues[0] + fishAndWildlifeHabitatAcresCountedValues[0];
            AcresTarget = FirmaWebConfiguration.SSMPAcresConstructedTarget;
            DustSuppressionAcresTarget = FirmaWebConfiguration.SSMPAcresConstructedTarget / 2;
            FishAndWildlifeHabitatAcresTarget = FirmaWebConfiguration.SSMPAcresConstructedTarget / 2;
            AcresInPlanningPercent = TotalAcresInPlanning / AcresTarget * 100;
            AcresInConstructionPercent = TotalAcresInConstruction / AcresTarget * 100;
            AcresCompletedPercent = TotalAcresCompleted / AcresTarget * 100;

            AreaTreatedForDustSuppression = dustSuppressionValues[0];
            FishAndWildlifeHabitatAcresCounted = fishAndWildlifeHabitatAcresCountedValues[0];

            AcresConstructedByTheNumbersViewPageContentViewData = new ViewPageContentViewData(acresConstructedByTheNumbersFirmaPage, currentFirmaSession);
            DustSuppressionViewPageContentViewData = new ViewPageContentViewData(dustSuppressionFirmaPage, currentFirmaSession);
            FishAndWildlifeHabitatViewPageContentViewData = new ViewPageContentViewData(fishAndWildlifeHabitatFirmaPage, currentFirmaSession);

            DustSuppressionPieChart = new ViewGoogleChartViewData(
                new List<GoogleChartJson> {dustSuppressionPieChart},
                dustSuppressionPieChart.GoogleChartConfiguration.Title, 366, true, true, true, false);

            FishAndWildlifeHabitatAcresCountedPieChart = new ViewGoogleChartViewData(
                new List<GoogleChartJson> {fishAndWildlifeHabitatAcresCountedPieChart},
                fishAndWildlifeHabitatAcresCountedPieChart.GoogleChartConfiguration.Title, 366, true, true, true, false);
         

            DustSuppressionValues = dustSuppressionValues;
            FishAndWildlifeHabitatAcresCountedValues = fishAndWildlifeHabitatAcresCountedValues;

            DustSuppressionHasData = dustSuppressionValues.Any(x => x > 0);
            FishAndWildlifeHabitatAcresCountedHasData = fishAndWildlifeHabitatAcresCountedValues.Any(x => x > 0);

            DustSuppressionColumnChart = new ViewGoogleChartViewData(dustSuppressionColumnCharts, "Completed Acres by Year", "dustSuppressionAcresCompleted", 366, true, true, true, true);
            DustSuppressionProjectToColorAndValue = dustSuppressionProjectToColorAndValue;

            FishAndWildlifeHabitatAcresCountedColumnChart = new ViewGoogleChartViewData(fishAndWildlifeHabitatAcresCountedColumnCharts, "Completed Acres by Year", "fishAndWildlifeHabitatAcresCountedAcresCompleted", 366, true, true, true, true);
            FishAndWildlifeHabitatAcresCountedProjectToColorAndValue = fishAndWildlifeHabitatAcresCountedProjectToColorAndValue;

            DustSuppressionPerformanceMeasure = dustSuppressionPerformanceMeasure;
            FishAndWildlifeHabitatAcresCountedPerformanceMeasure = fishAndWildlifeHabitatAcresCountedPerformanceMeasure;
            EndangeredSpeciesHabitatPerformanceMeasure = endangeredSpeciesHabitatPerformanceMeasure;
            PublicAmenitiesAndRecreationAccessPerformanceMeasure = publicAmenitiesAndRecreationAccessPerformanceMeasure;
            GrassBalesPlacedPerformanceMeasure = grassBalesPlacedPerformanceMeasure;
            StormwaterSpreadingAreasCreatedPerformanceMeasure = stormwaterSpreadingAreasCreatedPerformanceMeasure;
            SurfaceRougheningConductedPerformanceMeasure = surfaceRougheningConductedPerformanceMeasure;
            VegetationEnhancementConductedPerformanceMeasure = vegetationEnhancementConductedPerformanceMeasure;
            AquaticHabitatCreatedPerformanceMeasure = aquaticHabitatCreatedPerformanceMeasure;
            WetlandHabitatCreatedPerformanceMeasure = wetlandHabitatCreatedPerformanceMeasure;

            EndangeredSpeciesHabitatCreatedCount = endangeredSpeciesHabitatCreatedCount;
            PublicAmenitiesAndRecreationAccessCount = publicAmenitiesAndRecreationAccessCount;
            GrassBalesPlacedCount = grassBalesPlacedCount;
            StormwaterSpreadingAreasCreatedCount = stormwaterSpreadingAreasCreatedCount;
            SurfaceRougheningConductedCount = surfaceRougheningConductedCount;
            VegetationEnhancementConductedCount = vegetationEnhancementConductedCount;
            AquaticHabitatCreatedCount = aquaticHabitatCreatedCount;
            WetlandHabitatCreatedCount = wetlandHabitatCreatedCount;

        }
    }
}