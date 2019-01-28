using System;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class CostParameterSetModelExtensions
    {
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

        public static decimal? CalculateCapitalCostInYearOfExpenditureImpl(IProject project, decimal inflationRate, int currentRTPYearForPVCalculations)
        {
            if (!CanCalculateCapitalCostInYearOfExpenditure(project))
                return null;

            return FirmaMathUtilities.FutureValueOfPresentSum(project.EstimatedTotalCost.Value, inflationRate, currentRTPYearForPVCalculations, project.CompletionYear.Value);
        }

        public static bool CanCalculateCapitalCostInYearOfExpenditure(IProject project)
        {
            return project.FundingType == FundingTypeEnum.Capital.ToType() 
                   && project.EstimatedTotalCost.HasValue
                   && project.CompletionYear.HasValue 
                   && project.CompletionYear >= GetCurrentRTPYearForPVCalculations()
                   && project.ProjectStage.IsStagedIncludedInTransporationCostCalculations();
        }

        public static decimal? CalculateTotalRemainingOperatingCost(IProject project)
        {
            if (!project.CanCalculateTotalRemainingOperatingCostInYearOfExpenditure())
                return null;

            return CalculateTotalRemainingOperatingCostImpl(project.EstimatedAnnualOperatingCost.Value, GetLatestInflationRate(), GetCurrentRTPYearForPVCalculations(),
                project.ImplementationStartYear.Value,
                project.CompletionYear.Value);
        }

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

        public static bool CanCalculateTotalRemainingOperatingCostInYearOfExpenditure(this IProject project)
        {
            return project.FundingType == FundingTypeEnum.OperationsAndMaintenance.ToType() 
                   && project.EstimatedAnnualOperatingCost.HasValue
                   && project.CompletionYear.HasValue 
                   && project.ImplementationStartYear.HasValue 
                   && project.CompletionYear >= GetCurrentRTPYearForPVCalculations()
                   && project.ProjectStage.IsStagedIncludedInTransporationCostCalculations();
        }

        public static decimal? LifecycleOperatingCost(this IProject project)
        {
            if (!project.CanCalculateLifecycleOperatingCost())
                return null;

            return (project.CompletionYear - project.ImplementationStartYear)*project.EstimatedAnnualOperatingCost;
        }

        public static bool CanCalculateLifecycleOperatingCost(this IProject project)
        {
            return project.FundingType == FundingTypeEnum.OperationsAndMaintenance.ToType()
                   && project.EstimatedAnnualOperatingCost.HasValue
                   && project.CompletionYear.HasValue
                   && project.ImplementationStartYear.HasValue;
        }

        public static int GetCurrentRTPYearForPVCalculations()
        {
            var costParameterSet = HttpRequestStorage.DatabaseEntities.CostParameterSets.Latest();
            return costParameterSet?.CurrentYearForPVCalculations ?? DateTime.Now.Year;
        }

        public static decimal GetLatestInflationRate()
        {
            return HttpRequestStorage.DatabaseEntities.CostParameterSets.Latest().InflationRate;
        }
    }
}