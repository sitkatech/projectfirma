//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectUpdateCustomAttributeValue
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ProjectUpdateCustomAttributeValuePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectUpdateCustomAttributeValue>
    {
        public ProjectUpdateCustomAttributeValuePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectUpdateCustomAttributeValuePrimaryKey(ProjectUpdateCustomAttributeValue projectUpdateCustomAttributeValue) : base(projectUpdateCustomAttributeValue){}

        public static implicit operator ProjectUpdateCustomAttributeValuePrimaryKey(int primaryKeyValue)
        {
            return new ProjectUpdateCustomAttributeValuePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectUpdateCustomAttributeValuePrimaryKey(ProjectUpdateCustomAttributeValue projectUpdateCustomAttributeValue)
        {
            return new ProjectUpdateCustomAttributeValuePrimaryKey(projectUpdateCustomAttributeValue);
        }
    }
}