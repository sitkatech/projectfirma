namespace ProjectFirma.Web.Models
{
    public class ProjectBasicsUpdateDiff
    {
        public readonly ProjectUpdate OriginalProjectUpdate;
        public readonly ProjectUpdate ModifiedProjectUpdate;

        public ProjectBasicsUpdateDiff(ProjectUpdate originalProjectUpdate, ProjectUpdate modifiedProjectUpdate)
        {
            OriginalProjectUpdate = originalProjectUpdate;
            ModifiedProjectUpdate = modifiedProjectUpdate;
        }

        public bool HasChanged()
        {
            return 
                HasProjectDescriptionChanged() ||
                HasProjectStageChanged() ||
                HasPlanningDesignStartYearChanged() ||
                HasImplementationStartYearChanged() ||
                HasCompletionYearChanged() ||
                HasSecuredFundingChanged() ||
                HasEstimatedTotalCostChanged() ||
                HasEstimatedAnnualOperatingCostChanged();
        }

        private bool HasEstimatedAnnualOperatingCostChanged()
        {
            return OriginalProjectUpdate.EstimatedAnnualOperatingCost != ModifiedProjectUpdate.EstimatedAnnualOperatingCost;
        }

        private bool HasEstimatedTotalCostChanged()
        {
            return OriginalProjectUpdate.EstimatedTotalCost != ModifiedProjectUpdate.EstimatedTotalCost;
        }

        private bool HasSecuredFundingChanged()
        {
            return OriginalProjectUpdate.SecuredFunding != ModifiedProjectUpdate.SecuredFunding;
        }

        private bool HasCompletionYearChanged()
        {
            return OriginalProjectUpdate.CompletionYear != ModifiedProjectUpdate.CompletionYear;
        }

        private bool HasImplementationStartYearChanged()
        {
            return OriginalProjectUpdate.ImplementationStartYear != ModifiedProjectUpdate.ImplementationStartYear;
        }

        private bool HasPlanningDesignStartYearChanged()
        {
            return OriginalProjectUpdate.PlanningDesignStartYear != ModifiedProjectUpdate.PlanningDesignStartYear;
        }

        private bool HasProjectStageChanged()
        {
            return OriginalProjectUpdate.ProjectStageID != ModifiedProjectUpdate.ProjectStageID;
        }

        private bool HasProjectDescriptionChanged()
        {
            return OriginalProjectUpdate.ProjectDescription != ModifiedProjectUpdate.ProjectDescription;
        }
    }
}