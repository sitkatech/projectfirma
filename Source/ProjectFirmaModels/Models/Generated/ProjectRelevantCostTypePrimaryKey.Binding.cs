//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectRelevantCostType
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectRelevantCostTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectRelevantCostType>
    {
        public ProjectRelevantCostTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectRelevantCostTypePrimaryKey(ProjectRelevantCostType projectRelevantCostType) : base(projectRelevantCostType){}

        public static implicit operator ProjectRelevantCostTypePrimaryKey(int primaryKeyValue)
        {
            return new ProjectRelevantCostTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectRelevantCostTypePrimaryKey(ProjectRelevantCostType projectRelevantCostType)
        {
            return new ProjectRelevantCostTypePrimaryKey(projectRelevantCostType);
        }
    }
}