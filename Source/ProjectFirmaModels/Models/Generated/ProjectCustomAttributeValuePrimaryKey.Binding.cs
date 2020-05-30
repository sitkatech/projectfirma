//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectCustomAttributeValue
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectCustomAttributeValuePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectCustomAttributeValue>
    {
        public ProjectCustomAttributeValuePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectCustomAttributeValuePrimaryKey(ProjectCustomAttributeValue projectCustomAttributeValue) : base(projectCustomAttributeValue){}

        public static implicit operator ProjectCustomAttributeValuePrimaryKey(int primaryKeyValue)
        {
            return new ProjectCustomAttributeValuePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectCustomAttributeValuePrimaryKey(ProjectCustomAttributeValue projectCustomAttributeValue)
        {
            return new ProjectCustomAttributeValuePrimaryKey(projectCustomAttributeValue);
        }
    }
}