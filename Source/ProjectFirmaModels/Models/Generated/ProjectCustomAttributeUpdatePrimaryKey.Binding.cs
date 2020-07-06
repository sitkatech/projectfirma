//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectCustomAttributeUpdate
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectCustomAttributeUpdatePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectCustomAttributeUpdate>
    {
        public ProjectCustomAttributeUpdatePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectCustomAttributeUpdatePrimaryKey(ProjectCustomAttributeUpdate projectCustomAttributeUpdate) : base(projectCustomAttributeUpdate){}

        public static implicit operator ProjectCustomAttributeUpdatePrimaryKey(int primaryKeyValue)
        {
            return new ProjectCustomAttributeUpdatePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectCustomAttributeUpdatePrimaryKey(ProjectCustomAttributeUpdate projectCustomAttributeUpdate)
        {
            return new ProjectCustomAttributeUpdatePrimaryKey(projectCustomAttributeUpdate);
        }
    }
}