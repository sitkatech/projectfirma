//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectExpenditureRelevantCostType
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectExpenditureRelevantCostTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectExpenditureRelevantCostType>
    {
        public ProjectExpenditureRelevantCostTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectExpenditureRelevantCostTypePrimaryKey(ProjectExpenditureRelevantCostType projectExpenditureRelevantCostType) : base(projectExpenditureRelevantCostType){}

        public static implicit operator ProjectExpenditureRelevantCostTypePrimaryKey(int primaryKeyValue)
        {
            return new ProjectExpenditureRelevantCostTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectExpenditureRelevantCostTypePrimaryKey(ProjectExpenditureRelevantCostType projectExpenditureRelevantCostType)
        {
            return new ProjectExpenditureRelevantCostTypePrimaryKey(projectExpenditureRelevantCostType);
        }
    }
}