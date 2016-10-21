using ProjectFirma.Web.Common;
using LtInfo.Common; 

namespace ProjectFirma.Web.Models
{
    public partial class TransportationCostParameterSet : IAuditableEntity
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

            return CalculateCapitalCostInYearOfExpenditureImpl(project, GetLatestInflationRate());
        }

        //Only public for unit testing
        public static decimal? CalculateCapitalCostInYearOfExpenditureImpl(IProject project, decimal inflationRate)
        {
            if (!CanCalculateCapitalCostInYearOfExpenditure(project))
                return null;

            return ProjectFirmaMathUtilities.FutureValueOfPresentSum(project.EstimatedTotalCost.Value, inflationRate, GetCurrentRTPYearForPVCalculations(), project.CompletionYear.Value);
        }

        public static bool CanCalculateCapitalCostInYearOfExpenditure(IProject project)
        {
            return project.IsTransportationProject 
                && project.FundingType == FundingType.Capital 
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
                totalOperatingCost += ProjectFirmaMathUtilities.FutureValueOfPresentSum(annualCost, inflationRate, baseYear, i);
            }
            return totalOperatingCost;
        }

        public static bool CanCalculateTotalRemainingOperatingCostInYearOfExpenditure(IProject project)
        {
            return project.IsTransportationProject 
                && project.FundingType == FundingType.OperationsAndMaintenance 
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
            return HttpRequestStorage.DatabaseEntities.TransportationCostParameterSets.Latest().CurrentRTPYearForPVCalculations;
        }

        public static decimal GetLatestInflationRate()
        {
            return HttpRequestStorage.DatabaseEntities.TransportationCostParameterSets.Latest().InflationRate;
        }
    }
}