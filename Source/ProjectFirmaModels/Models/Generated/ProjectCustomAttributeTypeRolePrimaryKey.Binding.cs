//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectCustomAttributeTypeRole
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectCustomAttributeTypeRolePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectCustomAttributeTypeRole>
    {
        public ProjectCustomAttributeTypeRolePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectCustomAttributeTypeRolePrimaryKey(ProjectCustomAttributeTypeRole projectCustomAttributeTypeRole) : base(projectCustomAttributeTypeRole){}

        public static implicit operator ProjectCustomAttributeTypeRolePrimaryKey(int primaryKeyValue)
        {
            return new ProjectCustomAttributeTypeRolePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectCustomAttributeTypeRolePrimaryKey(ProjectCustomAttributeTypeRole projectCustomAttributeTypeRole)
        {
            return new ProjectCustomAttributeTypeRolePrimaryKey(projectCustomAttributeTypeRole);
        }
    }
}