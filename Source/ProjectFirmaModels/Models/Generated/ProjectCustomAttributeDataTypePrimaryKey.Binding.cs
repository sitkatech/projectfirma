//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectCustomAttributeDataType
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectCustomAttributeDataTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectCustomAttributeDataType>
    {
        public ProjectCustomAttributeDataTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectCustomAttributeDataTypePrimaryKey(ProjectCustomAttributeDataType projectCustomAttributeDataType) : base(projectCustomAttributeDataType){}

        public static implicit operator ProjectCustomAttributeDataTypePrimaryKey(int primaryKeyValue)
        {
            return new ProjectCustomAttributeDataTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectCustomAttributeDataTypePrimaryKey(ProjectCustomAttributeDataType projectCustomAttributeDataType)
        {
            return new ProjectCustomAttributeDataTypePrimaryKey(projectCustomAttributeDataType);
        }
    }
}