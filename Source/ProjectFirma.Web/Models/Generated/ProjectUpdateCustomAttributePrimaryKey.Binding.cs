//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectUpdateCustomAttribute
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ProjectUpdateCustomAttributePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectUpdateCustomAttribute>
    {
        public ProjectUpdateCustomAttributePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectUpdateCustomAttributePrimaryKey(ProjectUpdateCustomAttribute projectUpdateCustomAttribute) : base(projectUpdateCustomAttribute){}

        public static implicit operator ProjectUpdateCustomAttributePrimaryKey(int primaryKeyValue)
        {
            return new ProjectUpdateCustomAttributePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectUpdateCustomAttributePrimaryKey(ProjectUpdateCustomAttribute projectUpdateCustomAttribute)
        {
            return new ProjectUpdateCustomAttributePrimaryKey(projectUpdateCustomAttribute);
        }
    }
}