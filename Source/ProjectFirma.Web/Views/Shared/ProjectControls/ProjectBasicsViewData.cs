using LtInfo.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirma.Web.Views.Shared.ProjectControls
{
    public class ProjectBasicsViewData
    {
        public readonly Models.Project Project;
        public readonly bool UserHasProjectBudgetManagePermissions;
        public readonly bool UserHasTaggingPermissions;
        public readonly ProjectBasicsCalculatedCosts ProjectBasicsCalculatedCosts;
        public readonly ProjectTaxonomyViewData ProjectTaxonomyViewData;
        public readonly ProjectBasicsTagsViewData ProjectBasicsTagsViewData;

        public ProjectBasicsViewData(Models.Project project, bool userHasProjectBudgetManagePermissions, bool userHasTaggingPermissions, ProjectBasicsTagsViewData projectBasicsTagsViewData)
        {
            Project = project;
            UserHasProjectBudgetManagePermissions = userHasProjectBudgetManagePermissions;
            UserHasTaggingPermissions = userHasTaggingPermissions;
            ProjectBasicsTagsViewData = projectBasicsTagsViewData;
            ProjectTaxonomyViewData = new ProjectTaxonomyViewData(project);
            ProjectBasicsCalculatedCosts = new ProjectBasicsCalculatedCosts(project);
            
        }        
    }

    public class ProjectBasicsCalculatedCosts
    {
        public readonly decimal? CapitalCostInYearOfExpenditure;
        public readonly string EditInflationUrl;
        public readonly decimal InflationRate;
        public readonly decimal? TotalOperatingCostInYearOfExpenditure;
        public readonly int? StartYearForTotalOperatingCostCalculation;

        public ProjectBasicsCalculatedCosts(Models.Project project)
        {
            CapitalCostInYearOfExpenditure = Models.CostParameterSet.CalculateCapitalCostInYearOfExpenditure(project);
            EditInflationUrl = SitkaRoute<CostParameterSetController>.BuildUrlFromExpression(controller => controller.Detail());
            InflationRate = Models.CostParameterSet.GetLatestInflationRate();
            TotalOperatingCostInYearOfExpenditure = Models.CostParameterSet.CalculateTotalRemainingOperatingCost(project);
            StartYearForTotalOperatingCostCalculation = Models.CostParameterSet.StartYearForTotalCostCalculations(project);
        }
    }

}