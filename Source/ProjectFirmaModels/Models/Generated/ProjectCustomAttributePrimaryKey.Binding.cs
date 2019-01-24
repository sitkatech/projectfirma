//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectCustomAttribute
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectCustomAttributePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectCustomAttribute>
    {
        public ProjectCustomAttributePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectCustomAttributePrimaryKey(ProjectCustomAttribute projectCustomAttribute) : base(projectCustomAttribute){}

        public static implicit operator ProjectCustomAttributePrimaryKey(int primaryKeyValue)
        {
            return new ProjectCustomAttributePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectCustomAttributePrimaryKey(ProjectCustomAttribute projectCustomAttribute)
        {
            return new ProjectCustomAttributePrimaryKey(projectCustomAttribute);
        }
    }
}