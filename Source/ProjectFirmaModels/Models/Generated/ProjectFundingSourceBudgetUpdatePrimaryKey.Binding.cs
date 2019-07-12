//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectFundingSourceBudgetUpdate
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectFundingSourceBudgetUpdatePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectFundingSourceBudgetUpdate>
    {
        public ProjectFundingSourceBudgetUpdatePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectFundingSourceBudgetUpdatePrimaryKey(ProjectFundingSourceBudgetUpdate projectFundingSourceBudgetUpdate) : base(projectFundingSourceBudgetUpdate){}

        public static implicit operator ProjectFundingSourceBudgetUpdatePrimaryKey(int primaryKeyValue)
        {
            return new ProjectFundingSourceBudgetUpdatePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectFundingSourceBudgetUpdatePrimaryKey(ProjectFundingSourceBudgetUpdate projectFundingSourceBudgetUpdate)
        {
            return new ProjectFundingSourceBudgetUpdatePrimaryKey(projectFundingSourceBudgetUpdate);
        }
    }
}