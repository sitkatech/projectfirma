//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectRelevantCostTypeGroup
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectRelevantCostTypeGroupPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectRelevantCostTypeGroup>
    {
        public ProjectRelevantCostTypeGroupPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectRelevantCostTypeGroupPrimaryKey(ProjectRelevantCostTypeGroup projectRelevantCostTypeGroup) : base(projectRelevantCostTypeGroup){}

        public static implicit operator ProjectRelevantCostTypeGroupPrimaryKey(int primaryKeyValue)
        {
            return new ProjectRelevantCostTypeGroupPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectRelevantCostTypeGroupPrimaryKey(ProjectRelevantCostTypeGroup projectRelevantCostTypeGroup)
        {
            return new ProjectRelevantCostTypeGroupPrimaryKey(projectRelevantCostTypeGroup);
        }
    }
}