namespace ProjectFirma.Web.Views.Shared.ProjectControls
{
    public class ProjectBasicsCalculatedCostsViewData
    {
        public readonly Models.Project Project;

        public ProjectBasicsCalculatedCostsViewData(Models.Project project,
            decimal? capitalCostInYearOfExpenditure,
            bool userHasTransportationProjectBudgetManagePermissions,
            string editInflationUrl,
            decimal inflationRate,
            decimal? totalOperatingCostInYearOfExpenditure,
            int? startYearForTotalOperatingCostCalculation)
        {
            Project = project;
            CapitalCostInYearOfExpenditure = capitalCostInYearOfExpenditure;
            UserHasTransportationProjectBudgetManagePermissions = userHasTransportationProjectBudgetManagePermissions;
            EditInflationUrl = editInflationUrl;
            InflationRate = inflationRate;
            TotalOperatingCostInYearOfExpenditure = totalOperatingCostInYearOfExpenditure;
            StartYearForTotalOperatingCostCalculation = startYearForTotalOperatingCostCalculation;
        }

        public readonly decimal? CapitalCostInYearOfExpenditure;
        public readonly bool UserHasTransportationProjectBudgetManagePermissions;
        public readonly string EditInflationUrl;
        public readonly decimal InflationRate;
        public readonly decimal? TotalOperatingCostInYearOfExpenditure;
        public readonly int? StartYearForTotalOperatingCostCalculation;
    }
}