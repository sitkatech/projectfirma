//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectCustomAttributeType
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectCustomAttributeTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectCustomAttributeType>
    {
        public ProjectCustomAttributeTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectCustomAttributeTypePrimaryKey(ProjectCustomAttributeType projectCustomAttributeType) : base(projectCustomAttributeType){}

        public static implicit operator ProjectCustomAttributeTypePrimaryKey(int primaryKeyValue)
        {
            return new ProjectCustomAttributeTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectCustomAttributeTypePrimaryKey(ProjectCustomAttributeType projectCustomAttributeType)
        {
            return new ProjectCustomAttributeTypePrimaryKey(projectCustomAttributeType);
        }
    }
}