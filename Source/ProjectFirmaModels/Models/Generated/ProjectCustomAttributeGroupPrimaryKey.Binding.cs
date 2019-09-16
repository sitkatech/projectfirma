//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectCustomAttributeGroup
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectCustomAttributeGroupPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectCustomAttributeGroup>
    {
        public ProjectCustomAttributeGroupPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectCustomAttributeGroupPrimaryKey(ProjectCustomAttributeGroup projectCustomAttributeGroup) : base(projectCustomAttributeGroup){}

        public static implicit operator ProjectCustomAttributeGroupPrimaryKey(int primaryKeyValue)
        {
            return new ProjectCustomAttributeGroupPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectCustomAttributeGroupPrimaryKey(ProjectCustomAttributeGroup projectCustomAttributeGroup)
        {
            return new ProjectCustomAttributeGroupPrimaryKey(projectCustomAttributeGroup);
        }
    }
}