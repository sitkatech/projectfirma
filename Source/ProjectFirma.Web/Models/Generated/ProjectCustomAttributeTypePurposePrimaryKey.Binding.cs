//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectCustomAttributeTypePurpose
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ProjectCustomAttributeTypePurposePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectCustomAttributeTypePurpose>
    {
        public ProjectCustomAttributeTypePurposePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectCustomAttributeTypePurposePrimaryKey(ProjectCustomAttributeTypePurpose projectCustomAttributeTypePurpose) : base(projectCustomAttributeTypePurpose){}

        public static implicit operator ProjectCustomAttributeTypePurposePrimaryKey(int primaryKeyValue)
        {
            return new ProjectCustomAttributeTypePurposePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectCustomAttributeTypePurposePrimaryKey(ProjectCustomAttributeTypePurpose projectCustomAttributeTypePurpose)
        {
            return new ProjectCustomAttributeTypePurposePrimaryKey(projectCustomAttributeTypePurpose);
        }
    }
}