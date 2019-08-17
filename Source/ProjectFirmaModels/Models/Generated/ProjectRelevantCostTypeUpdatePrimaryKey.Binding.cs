//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectRelevantCostTypeUpdate
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectRelevantCostTypeUpdatePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectRelevantCostTypeUpdate>
    {
        public ProjectRelevantCostTypeUpdatePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectRelevantCostTypeUpdatePrimaryKey(ProjectRelevantCostTypeUpdate projectRelevantCostTypeUpdate) : base(projectRelevantCostTypeUpdate){}

        public static implicit operator ProjectRelevantCostTypeUpdatePrimaryKey(int primaryKeyValue)
        {
            return new ProjectRelevantCostTypeUpdatePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectRelevantCostTypeUpdatePrimaryKey(ProjectRelevantCostTypeUpdate projectRelevantCostTypeUpdate)
        {
            return new ProjectRelevantCostTypeUpdatePrimaryKey(projectRelevantCostTypeUpdate);
        }
    }
}