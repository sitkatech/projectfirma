//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectLocationAreaGroupType
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ProjectLocationAreaGroupTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectLocationAreaGroupType>
    {
        public ProjectLocationAreaGroupTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectLocationAreaGroupTypePrimaryKey(ProjectLocationAreaGroupType projectLocationAreaGroupType) : base(projectLocationAreaGroupType){}

        public static implicit operator ProjectLocationAreaGroupTypePrimaryKey(int primaryKeyValue)
        {
            return new ProjectLocationAreaGroupTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectLocationAreaGroupTypePrimaryKey(ProjectLocationAreaGroupType projectLocationAreaGroupType)
        {
            return new ProjectLocationAreaGroupTypePrimaryKey(projectLocationAreaGroupType);
        }
    }
}