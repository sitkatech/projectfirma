/*-----------------------------------------------------------------------
<copyright file="CostParameterSet.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
using ProjectFirma.Web.Common;
using LtInfo.Common; 

namespace ProjectFirma.Web.Models
{
    public partial class CostParameterSet : IAuditableEntity
    {
        public string AuditDescriptionString
        {
            get { return string.Format("Inflation Rate: {0}", InflationRate.ToStringPercent()); }
        }

        public static int? StartYearForTotalCostCalculations(IProject project)
        {
            return StartYearForTotalCostCalculationsImpl(project.ImplementationStartYear);
        }
        
        private static int? StartYearForTotalCostCalculationsImpl(int? startYear)
        {
            var currentRTPYearForPVCalculations = GetCurrentRTPYearForPVCalculations();

            return startYear.HasValue && startYear < currentRTPYearForPVCalculations
                ? currentRTPYearForPVCalculations : startYear;
        }

        public static decimal? CalculateCapitalCostInYearOfExpenditure(IProject project)
        {
            if (!CanCalculateCapitalCostInYearOfExpenditure(project))
                return null;

            return CalculateCapitalCostInYearOfExpenditureImpl(project, GetLatestInflationRate(), 2016);
        }

        //Only public for unit testing
        public static decimal? CalculateCapitalCostInYearOfExpenditureImpl(IProject project, decimal inflationRate, int currentRTPYearForPVCalculations)
        {
            if (!CanCalculateCapitalCostInYearOfExpenditure(project))
                return null;

            return FirmaMathUtilities.FutureValueOfPresentSum(project.EstimatedTotalCost.Value, inflationRate, currentRTPYearForPVCalculations, project.CompletionYear.Value);
        }

        public static bool CanCalculateCapitalCostInYearOfExpenditure(IProject project)
        {
            return project.FundingType == FundingType.Capital 
                && project.EstimatedTotalCost.HasValue
                && project.CompletionYear.HasValue 
                && project.CompletionYear >= GetCurrentRTPYearForPVCalculations()
                && project.ProjectStage.IsStagedIncludedInTransporationCostCalculations();
        }

        public static decimal? CalculateTotalRemainingOperatingCost(IProject project)
        {
            if (!CanCalculateTotalRemainingOperatingCostInYearOfExpenditure(project))
                return null;

            return CalculateTotalRemainingOperatingCostImpl(project.EstimatedAnnualOperatingCost.Value,
                GetLatestInflationRate(),
                GetCurrentRTPYearForPVCalculations(),
                project.ImplementationStartYear.Value,
                project.CompletionYear.Value);
        }

        //Only public for unit testing
        public static decimal? CalculateTotalRemainingOperatingCostImpl(decimal annualCost, decimal inflationRate, int baseYear, int startYear, int endYear)
        {
            var totalOperatingCost = 0m;
            var startYearForTotalOperatingCostCalculation = StartYearForTotalCostCalculationsImpl(startYear).Value;
            for (var i = startYearForTotalOperatingCostCalculation; i <= endYear; i++)
            {
                totalOperatingCost += FirmaMathUtilities.FutureValueOfPresentSum(annualCost, inflationRate, baseYear, i);
            }
            return totalOperatingCost;
        }

        public static bool CanCalculateTotalRemainingOperatingCostInYearOfExpenditure(IProject project)
        {
            return project.FundingType == FundingType.OperationsAndMaintenance 
                && project.EstimatedAnnualOperatingCost.HasValue
                && project.CompletionYear.HasValue 
                && project.ImplementationStartYear.HasValue 
                && project.CompletionYear >= GetCurrentRTPYearForPVCalculations()
                && project.ProjectStage.IsStagedIncludedInTransporationCostCalculations();
        }

        public static decimal? LifecycleOperatingCost(IProject project)
        {
            if (!CanCalculateLifecycleOperatingCost(project))
                return null;

            return (project.CompletionYear - project.ImplementationStartYear)*project.EstimatedAnnualOperatingCost;
        }

        public static bool CanCalculateLifecycleOperatingCost(IProject project)
        {
            return project.FundingType == FundingType.OperationsAndMaintenance
                && project.EstimatedAnnualOperatingCost.HasValue
                && project.CompletionYear.HasValue
                && project.ImplementationStartYear.HasValue;
        }

        public static int GetCurrentRTPYearForPVCalculations()
        {
            var costParameterSet = HttpRequestStorage.DatabaseEntities.CostParameterSets.Latest();
            return costParameterSet == null ? DateTime.Now.Year : costParameterSet.CurrentYearForPVCalculations;
        }

        public static decimal GetLatestInflationRate()
        {
            return HttpRequestStorage.DatabaseEntities.CostParameterSets.Latest().InflationRate;
        }
    }
}
