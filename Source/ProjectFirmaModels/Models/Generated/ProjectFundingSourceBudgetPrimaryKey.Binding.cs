//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectFundingSourceBudget
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectFundingSourceBudgetPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectFundingSourceBudget>
    {
        public ProjectFundingSourceBudgetPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectFundingSourceBudgetPrimaryKey(ProjectFundingSourceBudget projectFundingSourceBudget) : base(projectFundingSourceBudget){}

        public static implicit operator ProjectFundingSourceBudgetPrimaryKey(int primaryKeyValue)
        {
            return new ProjectFundingSourceBudgetPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectFundingSourceBudgetPrimaryKey(ProjectFundingSourceBudget projectFundingSourceBudget)
        {
            return new ProjectFundingSourceBudgetPrimaryKey(projectFundingSourceBudget);
        }
    }
}