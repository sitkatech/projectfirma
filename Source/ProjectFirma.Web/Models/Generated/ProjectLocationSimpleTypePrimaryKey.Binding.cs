//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectLocationSimpleType
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ProjectLocationSimpleTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectLocationSimpleType>
    {
        public ProjectLocationSimpleTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectLocationSimpleTypePrimaryKey(ProjectLocationSimpleType projectLocationSimpleType) : base(projectLocationSimpleType){}

        public static implicit operator ProjectLocationSimpleTypePrimaryKey(int primaryKeyValue)
        {
            return new ProjectLocationSimpleTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectLocationSimpleTypePrimaryKey(ProjectLocationSimpleType projectLocationSimpleType)
        {
            return new ProjectLocationSimpleTypePrimaryKey(projectLocationSimpleType);
        }
    }
}