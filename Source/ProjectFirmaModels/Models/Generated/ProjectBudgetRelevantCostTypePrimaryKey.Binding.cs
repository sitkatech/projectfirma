//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectBudgetRelevantCostType
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectBudgetRelevantCostTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectBudgetRelevantCostType>
    {
        public ProjectBudgetRelevantCostTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectBudgetRelevantCostTypePrimaryKey(ProjectBudgetRelevantCostType projectBudgetRelevantCostType) : base(projectBudgetRelevantCostType){}

        public static implicit operator ProjectBudgetRelevantCostTypePrimaryKey(int primaryKeyValue)
        {
            return new ProjectBudgetRelevantCostTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectBudgetRelevantCostTypePrimaryKey(ProjectBudgetRelevantCostType projectBudgetRelevantCostType)
        {
            return new ProjectBudgetRelevantCostTypePrimaryKey(projectBudgetRelevantCostType);
        }
    }
}