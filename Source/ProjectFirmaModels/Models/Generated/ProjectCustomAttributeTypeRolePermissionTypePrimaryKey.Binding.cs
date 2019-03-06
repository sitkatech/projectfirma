//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectCustomAttributeTypeRolePermissionType
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectCustomAttributeTypeRolePermissionTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectCustomAttributeTypeRolePermissionType>
    {
        public ProjectCustomAttributeTypeRolePermissionTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectCustomAttributeTypeRolePermissionTypePrimaryKey(ProjectCustomAttributeTypeRolePermissionType projectCustomAttributeTypeRolePermissionType) : base(projectCustomAttributeTypeRolePermissionType){}

        public static implicit operator ProjectCustomAttributeTypeRolePermissionTypePrimaryKey(int primaryKeyValue)
        {
            return new ProjectCustomAttributeTypeRolePermissionTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectCustomAttributeTypeRolePermissionTypePrimaryKey(ProjectCustomAttributeTypeRolePermissionType projectCustomAttributeTypeRolePermissionType)
        {
            return new ProjectCustomAttributeTypeRolePermissionTypePrimaryKey(projectCustomAttributeTypeRolePermissionType);
        }
    }
}