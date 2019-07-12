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
            {
                return null;
            }

            return CalculateCapitalCostInYearOfExpenditureImpl(project, GetLatestInflationRate(), 2016);
        }

        public static decimal? CalculateCapitalCostInYearOfExpenditureImpl(IProject project, decimal inflationRate, int currentRTPYearForPVCalculations)
        {
            if (!CanCalculateCapitalCostInYearOfExpenditure(project))
            {
                return null;
            }

            return FirmaMathUtilities.FutureValueOfPresentSum(project.EstimatedTotalCost.Value, inflationRate, currentRTPYearForPVCalculations, project.CompletionYear.Value);
        }

        public static bool CanCalculateCapitalCostInYearOfExpenditure(IProject project)
        {
            bool hasCapitalFundingType = project.FundingType == FundingType.BudgetVariesByYear;
            bool validCompletionYear = project.CompletionYear >= GetCurrentRTPYearForPVCalculations();
            bool isStagedIncluded = project.ProjectStage.IsStageIncludedInTransporationCostCalculations();

            return hasCapitalFundingType
                   && project.EstimatedTotalCost.HasValue
                   && project.CompletionYear.HasValue
                   && validCompletionYear
                   && isStagedIncluded;
        }

        public static bool CanCalculateTotalRemainingOperatingCostInYearOfExpenditure(this IProject project)
        {
            return project.FundingType == FundingType.BudgetSameEachYear
                   && project.EstimatedAnnualOperatingCost.HasValue
                   && project.CompletionYear.HasValue 
                   && project.ImplementationStartYear.HasValue 
                   && project.ProjectStage.IsStageIncludedInTransporationCostCalculations();
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