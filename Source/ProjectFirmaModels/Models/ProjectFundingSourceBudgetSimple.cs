namespace ProjectFirmaModels.Models
{
    public class ProjectFundingSourceBudgetSimple
    {

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ProjectFundingSourceBudgetSimple()
        {
        }

        public ProjectFundingSourceBudgetSimple(ProjectFundingSourceBudget projectFundingSourceBudget)
            : this()
        {
            ProjectID = projectFundingSourceBudget.ProjectID;
            FundingSourceID = projectFundingSourceBudget.FundingSourceID;
            TargetedAmount = projectFundingSourceBudget.TargetedAmount;
            SecuredAmount = projectFundingSourceBudget.SecuredAmount;
        }

        public ProjectFundingSourceBudgetSimple(ProjectFundingSourceBudgetUpdate projectFundingSourceBudgetUpdate)
        {
            ProjectUpdateBatchID = projectFundingSourceBudgetUpdate.ProjectUpdateBatchID;
            FundingSourceID = projectFundingSourceBudgetUpdate.FundingSourceID;
            TargetedAmount = projectFundingSourceBudgetUpdate.TargetedAmount;
            SecuredAmount = projectFundingSourceBudgetUpdate.SecuredAmount;
        }

        public ProjectFundingSourceBudget ToProjectFundingSourceBudget()
        {
            return new ProjectFundingSourceBudget(ProjectID, FundingSourceID) { SecuredAmount = SecuredAmount, TargetedAmount = TargetedAmount };
        }

        public int ProjectID { get; set; }
        public int ProjectUpdateBatchID { get; set; }
        public int FundingSourceID { get; set; }
        public decimal? SecuredAmount { get; set; }
        public decimal? TargetedAmount { get; set; }

        public ProjectFundingSourceBudgetUpdate ToProjectFundingSourceBudgetUpdate()
        {
            return new ProjectFundingSourceBudgetUpdate(ProjectUpdateBatchID, FundingSourceID) { SecuredAmount = SecuredAmount, TargetedAmount = TargetedAmount };
        }

        public bool AreBothValuesZero()
        {
            return
                SecuredAmount == 0 && TargetedAmount == 0;
        }
    }
}