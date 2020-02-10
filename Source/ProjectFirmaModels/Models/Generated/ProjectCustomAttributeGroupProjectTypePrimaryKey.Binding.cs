//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectCustomAttributeGroupProjectType
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectCustomAttributeGroupProjectTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectCustomAttributeGroupProjectType>
    {
        public ProjectCustomAttributeGroupProjectTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectCustomAttributeGroupProjectTypePrimaryKey(ProjectCustomAttributeGroupProjectType projectCustomAttributeGroupProjectType) : base(projectCustomAttributeGroupProjectType){}

        public static implicit operator ProjectCustomAttributeGroupProjectTypePrimaryKey(int primaryKeyValue)
        {
            return new ProjectCustomAttributeGroupProjectTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectCustomAttributeGroupProjectTypePrimaryKey(ProjectCustomAttributeGroupProjectType projectCustomAttributeGroupProjectType)
        {
            return new ProjectCustomAttributeGroupProjectTypePrimaryKey(projectCustomAttributeGroupProjectType);
        }
    }
}